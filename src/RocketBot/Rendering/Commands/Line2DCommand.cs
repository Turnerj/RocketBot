using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RocketBot.Rendering.Commands
{
	public class Line2DCommand : IRenderCommand
	{
		public Color Color { get; set; }
		public Vector2 Start { get; set; }
		public Vector2 End { get; set; }
	}
}
