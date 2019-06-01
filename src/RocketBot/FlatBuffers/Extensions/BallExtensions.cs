using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class BallExtensions
	{
		public static Offset<DesiredBallState> ToFlatBuffer(this Ball ball, FlatBufferBuilder builder)
		{
			DesiredBallState.StartDesiredBallState(builder);
			DesiredBallState.AddPhysics(builder, ball.Physics.ToFlatBuffer(builder));
			return DesiredBallState.EndDesiredBallState(builder);
		}

		public static void Update(this Ball ball, BallInfo partial)
		{
			if (partial.Physics.HasValue)
			{
				ball.Physics.Update(partial.Physics.Value);
			}

			if (partial.LatestTouch.HasValue)
			{
				if (ball.LatestTouch == null)
				{
					ball.LatestTouch = new BallTouch();
				}

				ball.LatestTouch.Update(partial.LatestTouch.Value);
			}
		}
	}
}
