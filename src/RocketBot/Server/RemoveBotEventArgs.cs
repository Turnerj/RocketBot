using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Server
{
	public class RemoveBotEventArgs : EventArgs
	{
		public int PlayerIndex { get; }

		public RemoveBotEventArgs(int playerIndex)
		{
			PlayerIndex = playerIndex;
		}
	}
}
