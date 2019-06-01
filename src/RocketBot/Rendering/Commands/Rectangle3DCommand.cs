using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RocketBot.Rendering.Commands
{
	public class Rectangle3DCommand : IRenderCommand
	{
		public Color Color { get; set; }
		public Vector3 Position { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public bool Filled { get; set; }

		/// <summary>
		/// When false, the <see cref="Position"/> origin is the upper left of the Rectangle
		/// </summary>
		public bool Centered { get; set; }
	}
}
