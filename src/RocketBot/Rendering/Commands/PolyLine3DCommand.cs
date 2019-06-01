using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace RocketBot.Rendering.Commands
{
	public class PolyLine3DCommand : IRenderCommand
	{
		public Color Color { get; set; }
		public IEnumerable<Vector3> Vectors { get; set; }
	}
}
