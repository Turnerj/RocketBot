using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RocketBot.Model
{
	public class ObjectPhysics
	{
		public Vector3 Location { get; set; }
		public Vector3 Velocity { get; set; }
		public ObjectRotation Rotation { get; set; } = new ObjectRotation();
		public Vector3 AngularVelocity { get; set; }
	}
}
