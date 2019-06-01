using RocketBot;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleBot
{
	class ExampleBot : RocketBotBase
	{
		public ExampleBot(string name, int team, int player) : base(name, team, player) { }

		public override Controller OnTick(WorldState worldState, IEnumerable<BallPredictionSlice> ballPrediction)
		{
			var controller = new Controller();

			var ballLocation = worldState.Ball.Physics.Location;
			var carPhysics = worldState.Players[PlayerIndex].Physics;
			var carLocation = carPhysics.Location;
			var carRotation = carPhysics.Rotation;

			var botToTargetAngle = Math.Atan2(ballLocation.Y - carLocation.Y, ballLocation.X - carLocation.X);
			var botFrontToTargetAngle = botToTargetAngle - carRotation.Yaw;
			// Correct the angle
			if (botFrontToTargetAngle < -Math.PI)
				botFrontToTargetAngle += 2 * Math.PI;
			if (botFrontToTargetAngle > Math.PI)
				botFrontToTargetAngle -= 2 * Math.PI;

			// Decide which way to steer in order to get to the ball.
			if (botFrontToTargetAngle > 0)
				controller.Steer = 1;
			else
				controller.Steer = -1;

			controller.Throttle = 1;

			return controller;
		}
	}
}
