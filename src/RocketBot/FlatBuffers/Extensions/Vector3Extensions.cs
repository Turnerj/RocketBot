using FlatBuffers;
using rlbot.flat;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class Vector3Extensions
	{
		public static Offset<Vector3Partial> ToFlatBufferPartial(this System.Numerics.Vector3 vector, FlatBufferBuilder builder)
		{
			Vector3Partial.StartVector3Partial(builder);
			Vector3Partial.AddX(builder, Float.CreateFloat(builder, vector.X));
			Vector3Partial.AddY(builder, Float.CreateFloat(builder, vector.Y));
			Vector3Partial.AddZ(builder, Float.CreateFloat(builder, vector.Z));
			return Vector3Partial.EndVector3Partial(builder);
		}

		public static Offset<Vector3> ToFlatBuffer(this System.Numerics.Vector3 vector, FlatBufferBuilder builder)
		{
			return Vector3.CreateVector3(builder, vector.X, vector.Y, vector.Z);
		}

		public static System.Numerics.Vector3 ToNumerics(this Vector3 partial)
		{
			return new System.Numerics.Vector3(partial.X, partial.Y, partial.Z);
		}
	}
}
