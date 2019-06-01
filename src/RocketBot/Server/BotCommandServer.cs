using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RocketBot.Server
{
	/// <summary>
	/// A class used for running a server to get bot data from Python clients.
	/// <para>E.g. Will receive "add MyBot 1 3 ", which means "Add a bot called MyBot to team 1 with index 3".</para>
	/// </summary>
	public class BotCommandServer
	{
		private Thread Thread { get; set; }
		private TcpListener Listener { get; set; }

		private bool HasEnvironmentInitialized { get; set; }

		public event Action<EnvironmentInitializedEventArgs> EnvironmentInitializedEvent;
		public event Action<AddBotEventArgs> AddBotEvent;
		public event Action<RemoveBotEventArgs> RemoveBotEvent;

		/// <summary>
		/// Event that gets raised whenever a message is received from the Python client.
		/// </summary>
		protected virtual void OnMessageReceived(string message)
		{
			if (message != "" || message != null)
			{
				var split = message.Split(new char[] { '\n' }, 5);

				if (split.Length > 1)
				{
					var command = split[0];
					if (command == "add")
					{
						if (!HasEnvironmentInitialized)
						{
							HasEnvironmentInitialized = true;

							var dllDirectory = split[4];
							EnvironmentInitializedEvent?.Invoke(new EnvironmentInitializedEventArgs(dllDirectory));
						}

						var name = split[1];
						var team = int.Parse(split[2]);
						var playerIndex = int.Parse(split[3]);
						AddBotEvent?.Invoke(new AddBotEventArgs(name, team, playerIndex));
					}
					else if (command == "remove")
					{
						var playerIndex = int.Parse(split[1]);
						RemoveBotEvent?.Invoke(new RemoveBotEventArgs(playerIndex));
					}
				}
			}
		}

		/// <summary>
		/// Starts the server, which continously listens for clients until it is stopped.
		/// </summary>
		/// <param name="port">The port to run the server on.</param>
		public void Start(int port)
		{
			if (Thread == null)
			{
				Thread = new Thread(() => Listen(port));
				Thread.Start();
			}
		}

		private void Listen(int port)
		{
			if (Listener == null)
			{
				Listener = new TcpListener(IPAddress.Loopback, port);
				Listener.Start();

				Console.WriteLine($"Listening for clients on {IPAddress.Loopback} on port {port}...");

				while (true)
				{
					using (var client = Listener.AcceptTcpClient())
					using (var stream = client.GetStream())
					{
						var buffer = new byte[client.ReceiveBufferSize];
						var bytes = stream.Read(buffer, 0, client.ReceiveBufferSize);
						var receivedString = Encoding.ASCII.GetString(buffer, 0, bytes);
						OnMessageReceived(receivedString);
					}
				}
			}
		}

		/// <summary>
		/// Stops the server if it is running.
		/// </summary>
		public void Stop()
		{
			if (Thread != null)
			{
				Thread.Abort();
				Thread = null;

				if (Listener != null)
				{
					Listener.Stop();
					Listener = null;
				}
			}

			HasEnvironmentInitialized = false;
		}
	}
}
