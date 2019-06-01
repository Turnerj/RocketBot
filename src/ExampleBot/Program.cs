using RocketBot;
using System;
using System.IO;

namespace ExampleBot.Rookie
{
	class Program
	{
		static void Main(string[] args)
		{
			var text = File.ReadAllLines("port.cfg")[0];
			var port = int.Parse(text);

			var botManager = new BotManager<TestBot>();
			botManager.Start(port);
		}
	}
}
