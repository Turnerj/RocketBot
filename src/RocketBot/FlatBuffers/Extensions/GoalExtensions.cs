using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class GoalExtensions
	{
		public static void Update(this Goal goal, GoalInfo partial)
		{
			goal.Team = partial.TeamNum;

			if (partial.Location.HasValue)
			{
				goal.Location = partial.Location.Value.ToNumerics();;
			}

			if (partial.Direction.HasValue)
			{
				goal.Direction = partial.Direction.Value.ToNumerics();
			}
		}
	}
}
