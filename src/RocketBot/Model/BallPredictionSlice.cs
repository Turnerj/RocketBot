using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Model
{
	public class BallPredictionSlice
	{
		public TimeSpan GameSeconds { get; set; }
		public ObjectPhysics Physics { get; set; } = new ObjectPhysics();
	}
}
