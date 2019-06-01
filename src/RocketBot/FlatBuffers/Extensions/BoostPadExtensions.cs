using FlatBuffers;
using rlbot.flat;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class BoostPadExtensions
	{
		public static void Update(this Model.BoostPad boostPad, rlbot.flat.BoostPad partial)
		{
			boostPad.IsFullBoost = partial.IsFullBoost;
			if (partial.Location.HasValue)
			{
				boostPad.Location = partial.Location.Value.ToNumerics();
			}
		}
	}
}
