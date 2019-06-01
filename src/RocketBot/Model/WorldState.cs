using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Model
{
	public class WorldState
	{
		public List<Player> Players { get; } = new List<Player>();
		public Ball Ball { get; set; } = new Ball();

		public List<BoostPad> BoostPads { get; set; } = new List<BoostPad>();
		public List<Goal> Goals { get; set; } = new List<Goal>();

		public float WorldGravityZ { get; set; }
		/// <summary>
		/// Regular game speed is 1.0
		/// </summary>
		public float GameSpeed { get; set; }

		public bool IsOvertime { get; set; }
		public bool IsUnlimitedTime { get; set; }
		/// <summary>
		/// Round is active when cars can move around. False during replays.
		/// </summary>
		public bool IsRoundActive { get; set; }
		public bool HasMatchEnded { get; set; }

		public TimeSpan SecondsElapsed { get; set; }
		public TimeSpan GameTimeRemaining { get; set; }
	}
}
