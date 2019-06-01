using System;
using System.Collections.Generic;
using System.Threading;

namespace RocketBot
{
	public class BotProcess<T> : IDisposable where T : RocketBotBase
	{
		public RocketBotBase Bot { get; private set; }
		private Thread Thread { get; set; }
		private EventWaitHandle WaitHandle { get; set; }

		public BotProcess(string name, int team, int playerIndex)
		{
			Bot = (T)Activator.CreateInstance(typeof(T), name, team, playerIndex);
		}

		public EventWaitHandle Start(IGameInterface gameInterface)
		{
			WaitHandle = new AutoResetEvent(false);
			Thread = new Thread(() => Run(gameInterface));
			Thread.Start();
			return WaitHandle;
		}

		private void Run(IGameInterface gameInterface)
		{
			Bot.SetRenderPipeline(new Rendering.RenderPipeline());

			while (!gameInterface.IsInitialized())
			{
				Thread.Sleep(100);
			}

			Console.WriteLine($"{Bot.Name} has started.");

			while (true)
			{
				var worldState = gameInterface.GetWorldState();
				if (!worldState.HasMatchEnded && worldState.IsRoundActive && worldState.Players.Count > Bot.PlayerIndex)
				{
					var ballPrediction = gameInterface.GetBallPrediction();
					var action = Bot.OnTick(worldState, ballPrediction);
					if (action != null)
					{
						gameInterface.PerformAction(action, Bot.PlayerIndex);
					}
					gameInterface.PerformRender(Bot.PlayerIndex, Bot.RenderPipeline);
				}

				WaitHandle.WaitOne();
			}
		}

		public void Stop()
		{
			Thread.Abort();
			WaitHandle.Dispose();
			Console.WriteLine($"{Bot.Name} has stopped.");
		}

		public void Dispose()
		{
			Stop();
		}
	}
}
