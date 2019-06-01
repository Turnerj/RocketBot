using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot.Extensions
{
	public static class Vector3Extensions
	{
		public static float Distance2d(this Vector3 source, Vector3 target)
		{
			var x2 = Math.Pow(target.X - source.X, 2);
			var y2 = Math.Pow(target.Y - source.Y, 2);
			return (float)Math.Sqrt(x2 + y2);
		}
	}
}
