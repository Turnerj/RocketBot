using FlatBuffers;
using rlbot.flat;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.FlatBuffers.Extensions
{
	public static class ColorExtensions
	{
		public static Offset<Color> ToFlatBuffer(this System.Drawing.Color color, FlatBufferBuilder builder)
		{
			return Color.CreateColor(builder, color.A, color.R, color.G, color.B);
		}
	}
}
