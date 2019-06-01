using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot
{
	public static class BotMovementHelper
	{
		public static double AngleToTarget(ObjectPhysics source, Vector3 target)
		{
			var sourceToTargetAngle = Math.Atan2(target.Y - source.Location.Y, target.X - source.Location.X);
			var sourceFrontToTargetAngle = sourceToTargetAngle - source.Rotation.Yaw;

			if (sourceFrontToTargetAngle < -Math.PI)
			{
				sourceFrontToTargetAngle += 2 * Math.PI;
			}
			else if (sourceFrontToTargetAngle > Math.PI)
			{
				sourceFrontToTargetAngle -= 2 * Math.PI;
			}

			return sourceFrontToTargetAngle;
		}

		public static bool VectorGreaterThan(Vector3 vector, int upperBound)
		{
			return vector.X > upperBound || vector.Y > upperBound || vector.Z > upperBound;
		}

		public static bool WithinRange(float range, float source, float target)
		{
			var minVal = Math.Min(source, target);
			var maxVal = Math.Min(source, target);
			return Math.Abs(maxVal - minVal) < range;
		}
	}
}
