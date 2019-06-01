using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class ObjectRotationExtensions
	{
		public static Offset<RotatorPartial> ToFlatBuffer(this ObjectRotation rotation, FlatBufferBuilder builder)
		{
			RotatorPartial.StartRotatorPartial(builder);
			RotatorPartial.AddPitch(builder, Float.CreateFloat(builder, rotation.Pitch));
			RotatorPartial.AddYaw(builder, Float.CreateFloat(builder, rotation.Yaw));
			RotatorPartial.AddRoll(builder, Float.CreateFloat(builder, rotation.Roll));
			return RotatorPartial.EndRotatorPartial(builder);
		}

		public static void Update(this ObjectRotation rotation, Rotator partial)
		{
			rotation.Pitch = partial.Pitch;
			rotation.Yaw = partial.Yaw;
			rotation.Roll = partial.Roll;
		}
	}
}
