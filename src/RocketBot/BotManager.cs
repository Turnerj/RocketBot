using rlbot.flat;
using RocketBot.Internal;
using RocketBot.Server;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.IO;
using RocketBot.Model;

namespace RocketBot
{
	/// <summary>
	/// Manages the C# bots and runs them.
	/// </summary>
	/// <typeparam name="T">The custom bot class that should be run.</typeparam>
	public class BotManager<T> where T : RocketBotBase
	{
		private List<BotProcess<T>> BotProcesses { get; } = new List<BotProcess<T>>();
		private ConcurrentDictionary<int, EventWaitHandle> ActiveBots { get; } = new ConcurrentDictionary<int, EventWaitHandle>();

		private BotCommandServer CommandServer { get; set; }
		private int Frequency { get; set; }

		private IGameInterface GameInterface { get; } = new FlatBuffers.FlatBuffersGameInterface();

		public BotManager() : this(60) { }

		/// <summary>
		/// Construct a new instance of BotManager.
		/// </summary>
		/// <param name="frequency">The frequency that the bot updates at: [1, 120]</param>
		public BotManager(int frequency)
		{
			if (frequency > 120 || frequency < 1)
				throw new ArgumentOutOfRangeException("frequency");

			Frequency = frequency;
		}

		/// <summary>
		/// Start the server and be ready to manage the bots.
		/// </summary>
		/// <param name="port">The port that the manager listens to for the Python clients.</param>
		public void Start(int port)
		{
			CommandServer = new BotCommandServer();
			CommandServer.EnvironmentInitializedEvent += eventArgs => GameInterface.Start(eventArgs.DllDirectory);
			CommandServer.AddBotEvent += eventArgs => AddBot(eventArgs.Name, eventArgs.Team, eventArgs.PlayerIndex);
			CommandServer.RemoveBotEvent += eventArgs => RemoveBot(eventArgs.PlayerIndex);
			CommandServer.Start(port);

			// Ensure best available resolution before starting the main loop to reduce CPU usage
			TimerResolutionInterop.Query(out int minRes, out _, out int currRes);
			if (currRes > minRes)
			{
				TimerResolutionInterop.SetResolution(minRes);
			}

			MainBotLoop();
		}

		/// <summary>
		/// Adds a bot to the <see cref="BotProcesses"/> list if the index is not there already.
		/// </summary>
		/// <param name="bot"></param>
		private void AddBot(string name, int team, int playerIndex)
		{
			// Only add a bot if botProcesses doesn't contain the index given in the parameters.
			if (!BotProcesses.Any(b => b.Bot.PlayerIndex == playerIndex))
			{
				var botProcess = new BotProcess<T>(name, team, playerIndex);
				BotProcesses.Add(botProcess);
				Console.WriteLine($"Added bot {name} for Team {team + 1}.");

				var waitHandle = botProcess.Start(GameInterface);
				ActiveBots.TryAdd(playerIndex, waitHandle);
			}
		}

		private void RemoveBot(int playerIndex)
		{
			var botProcess = BotProcesses.FirstOrDefault(b => b.Bot.PlayerIndex == playerIndex);
			if (botProcess != null)
			{
				ActiveBots.TryRemove(playerIndex, out var waitHandle);
				botProcess.Stop();
				BotProcesses.Remove(botProcess);
				Console.WriteLine($"{botProcess.Bot.Name} removed.");
			}
		}

		/// <summary>
		/// The main bot manager loop. This will continuously run the bots by setting <see cref="botRunEvent"/>.
		/// </summary>
		private void MainBotLoop()
		{
			var timerResolution = TimerResolutionInterop.CurrentResolution;
			var targetSleepTime = new TimeSpan(10000000 / Frequency);
			var stopwatch = new Stopwatch();

			while (true)
			{
				//Ensure bots are available to process
				while (BotProcesses.Count == 0)
				{
					Thread.Sleep(50);
				}

				// Start the timer
				stopwatch.Restart();

				// Set off events that end up running the bot code later down the line
				foreach (var waitHandles in ActiveBots.Values)
				{
					waitHandles.Set();
				}

				// Sleep efficiently (but inaccurately) for as long as we can
				var maxInaccurateSleepTime = targetSleepTime - stopwatch.Elapsed - timerResolution;
				if (maxInaccurateSleepTime > TimeSpan.Zero)
					Thread.Sleep(maxInaccurateSleepTime);

				// We can sleep the rest of the time accurately with the use of a spin-wait, this will drastically reduce the amount of duplicate packets when running at higher frequencies.
				while (stopwatch.Elapsed < targetSleepTime);
			}
		}
	}
}
