using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RocketBot.Rendering.Commands
{
	public class String3DCommand : IRenderCommand
	{
		public string Text { get; set; }
		public Color Color { get; set; }
		public Vector3 UpperLeft { get; set; }
		public int ScaleX { get; set; }
		public int ScaleY { get; set; }
	}
}
