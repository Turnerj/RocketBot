using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class BallPredictionSliceExtensions
	{
		public static void Update(this BallPredictionSlice ballPredictionSlice, PredictionSlice partial)
		{
			ballPredictionSlice.GameSeconds = new TimeSpan(0, 0, (int)partial.GameSeconds);

			if (partial.Physics.HasValue)
			{
				ballPredictionSlice.Physics.Update(partial.Physics.Value);
			}
		}
	}
}
