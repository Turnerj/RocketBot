using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot.Macros.Micros
{
	public class GoToTargetOptions
	{
		public ObjectPhysics PlayerPhysics { get; set; }
		public Vector3 Target { get; set; }
		public bool UseBoost { get; set; }
	}
}
