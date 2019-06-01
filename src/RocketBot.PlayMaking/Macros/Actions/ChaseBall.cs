using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using RocketBot.Extensions;
using RocketBot.Macros.Micros;
using RocketBot.Model;

namespace RocketBot.Macros.Actions
{
	public class ChaseBall : IMacroAction
	{
		public double PriorityMultiplier { get; set; } = 1;

		private class ActionModel
		{
			public ObjectPhysics Physics { get; set; }
			public Vector3 BallLocation { get; set; }
		}

		private ActionModel GetData(WorldState worldState, int playerIndex)
		{
			var player = worldState.Players[playerIndex];

			return new ActionModel
			{
				Physics = player.Physics,
				BallLocation = worldState.Ball.Physics.Location
			};
		}

		public double GetActionPriority(WorldState worldState, int playerIndex)
		{
			return 1;
		}

		public IEnumerable<IMicroAction> GetMicroActions(WorldState worldState, int playerIndex)
		{
			return GoToTarget.GetMicroActions((currentWorldState, currentPlayerIndex) =>
			{
				var data = GetData(currentWorldState, currentPlayerIndex);
				return new GoToTargetOptions
				{
					PlayerPhysics = data.Physics,
					Target = data.BallLocation,
					UseBoost = true
				};
			}, new TimeSpan(0, 0, 5));
		}
	}
}
