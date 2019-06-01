using System;
using RocketBot;
using RocketBot.Model;
using System.Numerics;
using RocketBot.Extensions;
using RocketBot.Rendering.Commands;
using System.Drawing;
using RocketBot.Macros;
using RocketBot.Macros.Actions;
using System.Collections.Generic;
using System.Linq;

namespace ExampleBot.Rookie
{
	class ExampleBot : RocketBotBase
	{
		private MacroManager Macros { get; }

		public ExampleBot(string name, int team, int playerIndex) : base(name, team, playerIndex)
		{
			Macros = new MacroManager(playerIndex, new IMacroAction[]
			{
				new ChaseBall
				{
					
				},
				new BoostPickup
				{
					
				}
			});
		}

		public override Controller OnTick(WorldState worldState, IEnumerable<BallPredictionSlice> ballPrediction)
		{
			var controller = new Controller();

			var ballLocation = worldState.Ball.Physics.Location;
			var carPhysics = worldState.Players[PlayerIndex].Physics;
			var carLocation = carPhysics.Location;

			RenderPipeline.Commands.AddRange(
				Macros.PrintDebug(worldState, 120)
			);

			//controller.Steer = BotMovementHelper.SteerToward(carPhysics, ballLocation);

			//var distanceToBall = carLocation.Distance2d(ballLocation);

			////Ball is higher than car
			//if (
			//	ballLocation.Z > carPhysics.Location.Z && 
			//	BotMovementHelper.WithinRange(50, carLocation.Z, ballLocation.Z) && 
			//	distanceToBall < 150
			//)
			//{
			//	controller.Pitch = -0.75f;
			//	controller.Boost = true;
			//	controller.Jump = true;
			//}

			////Speed up if far away
			//if (
			//	distanceToBall > 600 && 
			//	BotMovementHelper.WithinRange(0.25f, controller.Steer, 0)
			//)
			//{
			//	controller.Boost = true;
			//}

			//Pickup boost
			var nearestBoost = worldState.BoostPads.FindNearest(carLocation);

			RenderPipeline.Commands.Add(new Line3DCommand
			{
				Color = Color.Blue,
				Start = nearestBoost.Location,
				End = carLocation
			});

			//if (
			//	nearestBoost.Location.Distance2d(carLocation) < 600 &&
			//	nearestBoost.IsActive
			//)
			//{
			//	controller.Steer = BotMovementHelper.SteerToward(carPhysics, nearestBoost.Location);
			//}

			////Perform a handbrake turn
			//if (
			//	(controller.Steer == 1 || controller.Steer == -1) &&
			//	BotMovementHelper.VectorGreaterThan(carPhysics.Velocity, 40)
			//)
			//{
			//	controller.Handbrake = true;
			//}

			//// Set the throttle to 1 so the bot can move.
			//controller.Throttle = 1;

			RenderPipeline.Commands.Add(new Line3DCommand
			{
				Color = Color.Red,
				Start = ballLocation,
				End = carLocation
			});

			ShowPositions(worldState);

			ShowBallPrediction(ballPrediction);

			return Macros.GetController(worldState);
		}

		private void ShowBallPrediction(IEnumerable<BallPredictionSlice> ballPrediction)
		{
			RenderPipeline.Commands.Add(new PolyLine3DCommand
			{
				Color = Color.White,
				Vectors = ballPrediction.Select(s => s.Physics.Location)
			});
		}

		private void ShowPositions(WorldState worldState)
		{
			void RenderPosition(Vector3 vector, Color color)
			{
				RenderPipeline.Commands.Add(new String3DCommand
				{
					Color = color,
					UpperLeft = new Vector3(vector.X, vector.Y, vector.Z + 40),
					ScaleX = 1,
					ScaleY = 1,
					Text = $"[{Math.Round(vector.X)},{Math.Round(vector.Y)},{Math.Round(vector.Z)}]"
				});
			}

			RenderPosition(worldState.Ball.Physics.Location, Color.White);

			foreach (var player in worldState.Players)
			{
				var playerLocation = player.Physics.Location;
				RenderPosition(playerLocation, Color.Black);

				var rotation = player.Physics.Rotation;
				RenderPipeline.Commands.Add(new String3DCommand
				{
					Color = Color.Black,
					UpperLeft = new Vector3(playerLocation.X, playerLocation.Y, playerLocation.Z + 70),
					ScaleX = 1,
					ScaleY = 1,
					Text = $"[Y{Math.Round(rotation.Yaw)},P{Math.Round(rotation.Pitch)},R{Math.Round(rotation.Roll)}]"
				});

				//var angleToTarget = BotMovementHelper.AngleToTarget(player.Physics, worldState.Ball.Physics.Location);
				//RenderPipeline.Commands.Add(new String3DCommand
				//{
				//	Color = Color.Black,
				//	UpperLeft = new Vector3(playerLocation.X, playerLocation.Y, playerLocation.Z + 100),
				//	ScaleX = 1,
				//	ScaleY = 1,
				//	Text = $"[{angleToTarget}]"
				//});
			}

			foreach (var boostPad in worldState.BoostPads)
			{
				RenderPosition(boostPad.Location, Color.Yellow);
			}

			foreach (var goal in worldState.Goals)
			{
				RenderPosition(goal.Location, Color.Green);
			}
		}
	}
}
