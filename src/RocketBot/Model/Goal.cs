using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot.Model
{
	public class Goal
	{
		public int Team { get; set; }
		public Vector3 Location { get; set; }
		public Vector3 Direction { get; set; }
	}
}
