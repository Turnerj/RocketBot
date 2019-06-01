using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RocketBot.Rendering.Commands
{
	public class Line3DCommand : IRenderCommand
	{
		public Color Color { get; set; }
		public Vector3 Start { get; set; }
		public Vector3 End { get; set; }
	}
}
