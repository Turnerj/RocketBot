using RocketBot.Messaging;
using RocketBot.Model;
using RocketBot.Rendering.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot
{
	public interface IGameInterface
	{
		void Start(string dllDirectory);
		bool IsInitialized();
		WorldState GetWorldState();
		void SetWorldState(WorldState worldState);
		void PerformAction(Controller controller, int playerIndex);
		IEnumerable<BallPredictionSlice> GetBallPrediction();
		void PerformRender(int playerIndex, ICommandPipeline<IRenderCommand> renderCommands);
		void SendMessages(ICommandPipeline<MessageCommand> messageCommands);
	}
}
