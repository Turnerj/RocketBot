using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class WorldStateExtensions
	{
		public static Offset<DesiredGameState> ToFlatBuffer(this WorldState worldState, FlatBufferBuilder builder)
		{
			DesiredGameState.StartDesiredGameState(builder);

			DesiredGameState.AddBallState(builder, worldState.Ball.ToFlatBuffer(builder));

			DesiredGameInfoState.StartDesiredGameInfoState(builder);
			DesiredGameInfoState.AddGameSpeed(builder, Float.CreateFloat(builder, worldState.GameSpeed));
			DesiredGameInfoState.AddWorldGravityZ(builder, Float.CreateFloat(builder, worldState.WorldGravityZ));
			DesiredGameInfoState.EndDesiredGameInfoState(builder);

			var carStates = new List<Offset<DesiredCarState>>();
			foreach (var player in worldState.Players)
			{
				carStates.Add(player.ToFlatBuffer(builder));
			}
			var carStateVector = DesiredGameState.CreateCarStatesVector(builder, carStates.ToArray());
			DesiredGameState.AddCarStates(builder, carStateVector);

			return DesiredGameState.EndDesiredGameState(builder);
		}

		public static void Update(this WorldState worldState, GameTickPacket partial)
		{
			if (partial.Ball.HasValue)
			{
				worldState.Ball.Update(partial.Ball.Value);
			}
			
			for (int i = 0, l = partial.PlayersLength; i < l; i++)
			{
				var partialPlayer = partial.Players(i);
				if (partialPlayer.HasValue)
				{
					var player = worldState.Players.FirstOrDefault(p => p.Index == i);
					if (player == null)
					{
						player = new Player(partialPlayer.Value.Name, partialPlayer.Value.Team, i);
						worldState.Players.Add(player);
					}

					player.Update(partialPlayer.Value);
				}
			}

			for (int i = 0, l = partial.BoostPadStatesLength; i < l; i++)
			{
				var partialBoostPadState = partial.BoostPadStates(i);
				if (partialBoostPadState.HasValue)
				{
					var boostPad = worldState.BoostPads[i];
					boostPad.IsActive = partialBoostPadState.Value.IsActive;
					boostPad.Timer = new TimeSpan(0, 0, (int)partialBoostPadState.Value.Timer);
				}
			}

			if (partial.GameInfo.HasValue)
			{
				worldState.Update(partial.GameInfo.Value);
			}
		}

		public static void Update(this WorldState worldState, GameInfo partial)
		{
			worldState.GameSpeed = partial.GameSpeed;
			worldState.WorldGravityZ = partial.WorldGravityZ;

			worldState.IsOvertime = partial.IsOvertime;
			worldState.IsUnlimitedTime = partial.IsUnlimitedTime;
			worldState.IsRoundActive = partial.IsRoundActive;
			worldState.HasMatchEnded = partial.IsMatchEnded;

			worldState.SecondsElapsed = new TimeSpan(0, 0, (int)partial.SecondsElapsed);
			worldState.GameTimeRemaining = new TimeSpan(0, 0, (int)partial.GameTimeRemaining);
		}

		public static void Update(this WorldState worldState, FieldInfo partial)
		{
			for (int i = 0, l = partial.BoostPadsLength; i < l; i++)
			{
				if (i == worldState.BoostPads.Count)
				{
					worldState.BoostPads.Add(new Model.BoostPad());
				}

				var partialBoostPad = partial.BoostPads(i);
				if (partialBoostPad.HasValue)
				{
					worldState.BoostPads[i].Update(partialBoostPad.Value);
				}
			}

			for (int i = 0, l = partial.GoalsLength; i < l; i++)
			{
				if (i == worldState.Goals.Count)
				{
					worldState.Goals.Add(new Goal());
				}

				var partialGoal = partial.Goals(i);
				if (partialGoal.HasValue)
				{
					worldState.Goals[i].Update(partialGoal.Value);
				}
			}
		}
	}
}
