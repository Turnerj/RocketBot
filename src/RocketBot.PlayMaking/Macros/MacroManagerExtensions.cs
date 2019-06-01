using RocketBot.Model;
using RocketBot.Rendering.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;

namespace RocketBot.Macros
{
	public static class MacroManagerExtensions
	{
		public static IEnumerable<IRenderCommand> PrintDebug(this MacroManager manager, WorldState worldState, int zOffset = 0)
		{
			var carLocation = worldState.Players[manager.PlayerIndex].Physics.Location;
			var macroPriorities = manager.GetMacrosByPriority(worldState).Take(3).OrderBy(m => m.Priority).ToArray();

			for (int i = 0, l = macroPriorities.Length; i < l; i++)
			{
				var macroPriority = macroPriorities[i];
				var macro = macroPriority.Action;
				var displayName = macro.GetType().Name;

				yield return new String3DCommand
				{
					Color = Color.OrangeRed,
					UpperLeft = new Vector3(carLocation.X, carLocation.Y, carLocation.Z + zOffset + (15 * i)),
					ScaleX = 1,
					ScaleY = 1,
					Text = $"[{macroPriority.Priority.ToString("0.00")} - {macro.GetType().Name}]"
				};
			}
		}
	}
}
