using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using FlatBuffers;
using rlbot.flat;
using RocketBot.FlatBuffers.Extensions;
using RocketBot.Messaging;
using RocketBot.Model;
using RocketBot.Rendering.Commands;

namespace RocketBot.FlatBuffers
{
	public class FlatBuffersGameInterface : IGameInterface
	{
		private FlatBuffersRenderer Renderer { get; } = new FlatBuffersRenderer();

		private TResult ExternalCall<TResult>(Func<ByteBufferStruct> externalCall, Func<ByteBuffer, TResult> constructFunc)
		{
			var byteBuffer = externalCall();
			if (byteBuffer.size < 4)
			{
				return default;
			}

			byte[] bufferBytes = new byte[byteBuffer.size];
			Marshal.Copy(byteBuffer.ptr, bufferBytes, 0, byteBuffer.size);
			ExternalGame.Free(byteBuffer.ptr);

			return constructFunc(new ByteBuffer(bufferBytes));
		}

		public void Start(string dllDirectory)
		{
			if (Directory.Exists(dllDirectory))
			{
				// The folder containing the bot runner executable MUST contain a dll folder containing an interface DLL.
				// There is a 32 bit version and a 64 bit version of the interface DLL.
				// We want to use the right one depending on the bitness we are running on.
				var dllName = Environment.Is64BitProcess ? "RLBot_Core_Interface.dll" : "RLBot_Core_Interface_32.dll";

				Directory.CreateDirectory("dll");
				try
				{
					var sourceDll = Path.Combine(dllDirectory, dllName);
					File.Copy(sourceDll, ExternalGame.InterfaceDllPath, true);
				}
				catch (IOException)
				{
					// DLL is being used, therefore don't copy.
				}
			}
		}

		public bool IsInitialized()
		{
			return ExternalGame.IsInitialized();
		}

		public IEnumerable<BallPredictionSlice> GetBallPrediction()
		{
			var externBallPrediction = ExternalCall(
				() => ExternalGame.GetBallPrediction(),
				byteBuffer => BallPrediction.GetRootAsBallPrediction(byteBuffer)
			);

			for (int i = 0, l = externBallPrediction.SlicesLength; i < l; i++)
			{
				var externSlice = externBallPrediction.Slices(i);
				if (externSlice.HasValue)
				{
					var slice = new BallPredictionSlice();
					slice.Update(externSlice.Value);
					yield return slice;
				}
			}
		}

		public WorldState GetWorldState()
		{
			var worldState = new WorldState();

			var fieldInfo = ExternalCall(
				() => ExternalGame.UpdateFieldInfoFlatbuffer(),
				byteBuffer => FieldInfo.GetRootAsFieldInfo(byteBuffer)
			);
			if (fieldInfo.Equals(default(FieldInfo)))
			{
				return null;
			}
			worldState.Update(fieldInfo);

			var gameTickPacket = ExternalCall(
				() => ExternalGame.UpdateLiveDataPacketFlatbuffer(), 
				byteBuffer => GameTickPacket.GetRootAsGameTickPacket(byteBuffer)
			);
			if (gameTickPacket.Equals(default(GameTickPacket)))
			{
				return null;
			}
			worldState.Update(gameTickPacket);

			return worldState;
		}

		public void PerformAction(Controller controller, int playerIndex)
		{
			var builder = new FlatBufferBuilder(50);
			var playerInput = PlayerInput.CreatePlayerInput(builder, playerIndex, ControllerState.CreateControllerState(
				builder,
				controller.Throttle,
				controller.Steer,
				controller.Pitch,
				controller.Yaw,
				controller.Roll,
				controller.Jump,
				controller.Boost,
				controller.Handbrake
			));

			builder.Finish(playerInput.Value);
			var bytes = builder.SizedByteArray();

			var status = (ExternalGameStatusCode)ExternalGame.UpdatePlayerInputFlatbuffer(bytes, bytes.Length);
			if (status != ExternalGameStatusCode.Success && status != ExternalGameStatusCode.BufferOverfilled)
			{
				throw new InvalidOperationException(status.ToString());
			}
		}

		public void PerformRender(int playerIndex, ICommandPipeline<IRenderCommand> renderCommands)
		{
			var commands = renderCommands.TakeCommands();
			var builder = Renderer.BuildRender(playerIndex, commands);
			var bytes = builder.SizedByteArray();

			var status = (ExternalGameStatusCode)ExternalGame.RenderGroup(bytes, bytes.Length);
			if (status != ExternalGameStatusCode.Success && status != ExternalGameStatusCode.BufferOverfilled)
			{
				throw new InvalidOperationException(status.ToString());
			}
		}

		public void SendMessages(ICommandPipeline<MessageCommand> messageCommands)
		{
			throw new NotImplementedException();
		}

		public void SetWorldState(WorldState worldState)
		{
			var builder = new FlatBufferBuilder(100);
			var desiredState = worldState.ToFlatBuffer(builder);

			builder.Finish(desiredState.Value);
			var bytes = builder.SizedByteArray();

			var status = (ExternalGameStatusCode)ExternalGame.SetGameState(bytes, bytes.Length);
			if (status != ExternalGameStatusCode.Success && status != ExternalGameStatusCode.BufferOverfilled)
			{
				throw new InvalidOperationException(status.ToString());
			}
		}
	}
}
