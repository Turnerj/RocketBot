using RocketBot.Extensions;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot.Macros.Micros
{
	public static class GoToTarget
	{
		public static IEnumerable<IMicroAction> GetMicroActions(Func<WorldState, int, GoToTargetOptions> tickAction, TimeSpan microSpan)
		{
			return MicroAction.FrequentAction((worldState, playerIndex) =>
			{
				var options = tickAction(worldState, playerIndex);

				var angle = BotMovementHelper.AngleToTarget(options.PlayerPhysics, options.Target);
				var absAngle = Math.Abs(angle);
				var steeringValue = (float)Math.Max(-1, Math.Min(1, angle));

				var throttle = 1f;
				var applyHandbrake = false;
				var applyBoost = false;

				if (absAngle > 1.8 && options.PlayerPhysics.Velocity.Length() > 10)
				{
					applyHandbrake = true;
				}
				else if (absAngle > 1.2)
				{
					throttle = (float)((absAngle - 1.2) * 0.5);
				}

				if (options.UseBoost && absAngle < 1)
				{
					applyBoost = true;
				}

				return new Controller
				{
					Steer = steeringValue,
					Handbrake = applyHandbrake,
					Throttle = throttle,
					Boost = applyBoost
				};

			}, 100, microSpan);
		}
	}
}
