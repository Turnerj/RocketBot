using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot.Model
{
	public class BallTouch
	{
		public int Team { get; set; }
		public string PlayerName { get; set; }
		public float GameSeconds { get; set; }

		public Vector3 Location { get; set; }
		public Vector3 Direction { get; set; }
	}
}
