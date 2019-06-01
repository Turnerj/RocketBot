using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class PlayerExtensions
	{
		public static Offset<DesiredCarState> ToFlatBuffer(this Player player, FlatBufferBuilder builder)
		{
			DesiredCarState.StartDesiredCarState(builder);
			DesiredCarState.AddPhysics(builder, player.Physics.ToFlatBuffer(builder));
			DesiredCarState.AddJumped(builder, Bool.CreateBool(builder, player.Jumped));
			DesiredCarState.AddDoubleJumped(builder, Bool.CreateBool(builder, player.DoubleJumped));
			DesiredCarState.AddBoostAmount(builder, Float.CreateFloat(builder, player.BoostAmount));
			return DesiredCarState.EndDesiredCarState(builder);
		}

		public static void Update(this Player player, PlayerInfo partial)
		{
			player.IsBot = partial.IsBot;

			player.Jumped = partial.Jumped;
			player.DoubleJumped = partial.DoubleJumped;
			player.BoostAmount = partial.Boost;

			player.IsDemolished = partial.IsDemolished;
			player.HasWheelContact = partial.HasWheelContact;
			player.IsSupersonic = partial.IsSupersonic;

			if (partial.Physics.HasValue)
			{
				player.Physics.Update(partial.Physics.Value);
			}

			if (partial.ScoreInfo.HasValue)
			{
				player.Stats.Update(partial.ScoreInfo.Value);
			}
		}
	}
}
