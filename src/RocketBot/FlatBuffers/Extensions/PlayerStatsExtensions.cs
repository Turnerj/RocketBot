using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class PlayerStatsExtensions
	{
		public static void Update(this PlayerStats stats, ScoreInfo partial)
		{
			stats.Score = partial.Score;
			stats.Goals = partial.Goals;
			stats.OwnGoals = partial.OwnGoals;
			stats.Assists = partial.Assists;
			stats.Saves = partial.Saves;
			stats.Shots = partial.Shots;
			stats.Demolitions = partial.Demolitions;
		}
	}
}
