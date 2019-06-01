using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using RocketBot.Extensions;
using RocketBot.Macros.Micros;
using RocketBot.Model;

namespace RocketBot.Macros.Actions
{
	public class BoostPickup : IMacroAction
	{
		public double PriorityMultiplier { get; set; } = 1;

		/// <summary>
		/// The amount greater boost that a full boost pad gives compared to a normal one
		/// </summary>
		public const double FullBoostMulitplier = 8.3;

		/// <summary>
		/// Out-of-the-way distance to travel for a normal boost pickup
		/// </summary>
		public int MaxNormalDistance { get; set; } = 1000;

		/// <summary>
		/// Out-of-the-way distance to travel for a full boost pickup
		/// </summary>
		public int MaxFullDistance { get; set; } = 1500;

		/// <summary>
		/// Boost amount to aim for between 0 and 100
		/// </summary>
		public int TargetBoostAmount { get; set; } = 80;

		private class ActionModel
		{
			public ObjectPhysics PlayerPhysics { get; set; }
			public int CurrentBoost { get; set; }
			public double BaseBoostPriority { get; set; }
			public BoostPad NearestFull { get; set; }
			public double FullBoostPriority { get; set; }
			public BoostPad NearestNormal { get; set; }
			public double NormalBoostPriority { get; set; }
		}

		private ActionModel GetData(WorldState worldState, int playerIndex)
		{
			var player = worldState.Players[playerIndex];
			var physics = player.Physics;

			var data = new ActionModel
			{
				PlayerPhysics = player.Physics,
				CurrentBoost = (int)(player.BoostAmount * 100),
				NearestFull = worldState.BoostPads.Where(b => b.IsActive && b.IsFullBoost)
					.Where(b => 
						Math.Abs(BotMovementHelper.AngleToTarget(player.Physics, b.Location)) < Math.PI / 2
					)
					.FindNearest(physics.Location),
				NearestNormal = worldState.BoostPads.Where(b => b.IsActive && !b.IsFullBoost)
					.Where(b =>
						Math.Abs(BotMovementHelper.AngleToTarget(player.Physics, b.Location)) < Math.PI / 2
					).FindNearest(physics.Location)
			};

			data.BaseBoostPriority = 1 - data.CurrentBoost / TargetBoostAmount;
			data.FullBoostPriority = GetDistancePriority(data.NearestFull, data.PlayerPhysics) * FullBoostMulitplier;
			data.NormalBoostPriority = GetDistancePriority(data.NearestNormal, data.PlayerPhysics);

			return data;
		}

		private double GetDistancePriority(BoostPad boostPad, ObjectPhysics playerPhysics)
		{
			if (boostPad == null)
			{
				return 0;
			}

			var playerLocation = playerPhysics.Location;
			var rawDistance = playerLocation.Distance2d(boostPad.Location);
			var maxDistance = boostPad.IsFullBoost ? MaxFullDistance : MaxNormalDistance;
			var angleToBoost = Math.Abs(BotMovementHelper.AngleToTarget(playerPhysics, boostPad.Location));
			return (1 - (rawDistance / maxDistance)) * (1 - (angleToBoost / (Math.PI / 2)));
		}

		public double GetActionPriority(WorldState worldState, int playerIndex)
		{
			var data = GetData(worldState, playerIndex);
			return data.BaseBoostPriority * Math.Max(data.NormalBoostPriority, data.FullBoostPriority);
		}

		public IEnumerable<IMicroAction> GetMicroActions(WorldState worldState, int playerIndex)
		{
			return GoToTarget.GetMicroActions((currentWorldState, currentPlayerIndex) =>
			{
				var data = GetData(worldState, playerIndex);
				var targetBoostPad = data.NormalBoostPriority > data.FullBoostPriority ? data.NearestNormal : data.NearestFull;

				return new GoToTargetOptions
				{
					PlayerPhysics = data.PlayerPhysics,
					Target = targetBoostPad.Location,
					UseBoost = false
				};
			}, new TimeSpan(0, 0, 2));
		}
	}
}
