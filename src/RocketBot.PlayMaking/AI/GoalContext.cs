using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.AI
{
	public class GoalContext
	{
		public Ball Ball { get; set; }
		public Player PlayerWithPosession { get; set; }
		public IEnumerable<BallPredictionSlice> BallPrediction { get; set; }
	}
}
