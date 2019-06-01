using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class BallTouchExtensions
	{
		public static void Update(this BallTouch touch, Touch partial)
		{
			touch.Team = partial.Team;
			touch.PlayerName = partial.PlayerName;
			touch.GameSeconds = partial.GameSeconds;

			if (partial.Location.HasValue)
			{
				touch.Location = partial.Location.Value.ToNumerics();
			}

			if (partial.Normal.HasValue)
			{
				touch.Direction = partial.Normal.Value.ToNumerics();
			}
		}
	}
}
