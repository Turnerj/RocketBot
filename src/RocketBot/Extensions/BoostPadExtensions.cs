using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RocketBot.Extensions
{
	public static class BoostPadExtensions
	{
		public static BoostPad FindNearest(this IEnumerable<BoostPad> boostPad, Vector3 location)
		{
			return boostPad.OrderBy(b => b.Location.Distance2d(location)).FirstOrDefault();
		}
	}
}
