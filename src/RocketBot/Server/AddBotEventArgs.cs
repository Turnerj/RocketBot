using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Server
{
	public class AddBotEventArgs : EventArgs
	{
		public string Name { get; }
		public int Team { get; }
		public int PlayerIndex { get; }

		public AddBotEventArgs(string name, int team, int playerIndex)
		{
			Name = name;
			Team = team;
			PlayerIndex = playerIndex;
		}
	}
}
