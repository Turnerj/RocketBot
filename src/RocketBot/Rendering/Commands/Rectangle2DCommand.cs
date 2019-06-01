using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RocketBot.Rendering.Commands
{
	public class Rectangle2DCommand : IRenderCommand
	{
		public Color Color { get; set; }
		public Vector2 UpperLeft { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public bool Filled { get; set; }
	}
}
