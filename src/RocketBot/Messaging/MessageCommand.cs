using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Messaging
{
	public abstract class MessageCommand
	{
		public int PlayerIndex { get; set; }
		public bool TeamOnly { get; set; }
	}
}
