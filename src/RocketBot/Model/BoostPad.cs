using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot.Model
{
	public class BoostPad
	{
		public Vector3 Location { get; set; }
		public bool IsFullBoost { get; set; }
		public bool IsActive { get; set; }
		public TimeSpan Timer { get; set; }
	}
}
