using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Model
{
	public class Player
	{
		public string Name { get; }
		public int Team { get; }
		public int Index { get; }

		public bool IsBot { get; set; }

		public bool Jumped { get; set; }
		public bool DoubleJumped { get; set; }
		public float BoostAmount { get; set; }

		public bool IsDemolished { get; set; }
		public bool HasWheelContact { get; set; }
		public bool IsSupersonic { get; set; }

		public PlayerStats Stats { get; set; } = new PlayerStats();

		public ObjectPhysics Physics { get; set; } = new ObjectPhysics();

		public Player(string name, int team, int playerIndex)
		{
			Name = name;
			Team = team;
			Index = playerIndex;
		}
	}
}
