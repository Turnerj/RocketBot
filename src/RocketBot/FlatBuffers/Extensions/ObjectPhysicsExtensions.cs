using FlatBuffers;
using rlbot.flat;
using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class ObjectPhysicsExtensions
	{
		public static Offset<DesiredPhysics> ToFlatBuffer(this ObjectPhysics physics, FlatBufferBuilder builder)
		{
			DesiredPhysics.StartDesiredPhysics(builder);
			DesiredPhysics.AddLocation(builder, physics.Location.ToFlatBufferPartial(builder));
			DesiredPhysics.AddVelocity(builder, physics.Velocity.ToFlatBufferPartial(builder));
			DesiredPhysics.AddRotation(builder, physics.Rotation.ToFlatBuffer(builder));
			DesiredPhysics.AddAngularVelocity(builder, physics.AngularVelocity.ToFlatBufferPartial(builder));
			return DesiredPhysics.EndDesiredPhysics(builder);
		}

		public static void Update(this ObjectPhysics physics, Physics partial)
		{
			if (partial.Location.HasValue)
			{
				physics.Location = partial.Location.Value.ToNumerics();
			}

			if (partial.Velocity.HasValue)
			{
				physics.Velocity = partial.Velocity.Value.ToNumerics();
			}

			if (partial.Rotation.HasValue)
			{
				physics.Rotation.Update(partial.Rotation.Value);
			}

			if (partial.AngularVelocity.HasValue)
			{
				physics.AngularVelocity = partial.AngularVelocity.Value.ToNumerics();
			}
		}
	}
}
