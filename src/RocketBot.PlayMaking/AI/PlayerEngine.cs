using RocketBot.AI.Goals;
using RocketBot.Extensions;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketBot.AI
{
	public class PlayerEngine
	{
		public int PlayerIndex { get; }
		public IEnumerable<IGoal> AvailableGoals { get; }

		private GoalContext GoalContext { get; set; }

		public PlayerEngine(int playerIndex)
		{
			PlayerIndex = playerIndex;
			AvailableGoals = new IGoal[]
			{
				new Attack(),
				new Defend(),
				new Possess()
			};
		}

		public PlayerEngine(int playerIndex, IEnumerable<IGoal> availableGoals)
		{
			PlayerIndex = playerIndex;
			AvailableGoals = availableGoals;
		}

		public void UpdateGoalContext(WorldState worldState)
		{
			var team = worldState.Players.Where(p => p.Index == PlayerIndex).Select(p => p.Team).FirstOrDefault();
			var opponentGoal = worldState.Goals.Where(g => g.Team == team).FirstOrDefault();
			var yourGoal = worldState.Goals.Where(g => g.Team != team).FirstOrDefault();

			var ballLocation = worldState.Ball.Physics.Location;

			var distanceToOpponentGoal = ballLocation.Distance2d(opponentGoal.Location);
			var distanceToYourGoal = ballLocation.Distance2d(yourGoal.Location);

			GoalContext = new GoalContext
			{
				Ball = worldState.Ball,
				PlayerWithPosession = null,
				//BallPrediction = worldState.BallPrediction,
			};
		}
	}
}
