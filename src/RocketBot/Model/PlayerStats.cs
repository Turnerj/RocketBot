using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Model
{
	public class PlayerStats
	{
		public int Score { get; set; }
		public int Goals { get; set; }
		public int OwnGoals { get; set; }
		public int Assists { get; set; }
		public int Saves { get; set; }
		public int Shots { get; set; }
		public int Demolitions { get; set; }
	}
}
