using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Model
{
	public class Ball
	{
		public ObjectPhysics Physics { get; set; } = new ObjectPhysics();
		public BallTouch LatestTouch { get; set; }
	}
}
