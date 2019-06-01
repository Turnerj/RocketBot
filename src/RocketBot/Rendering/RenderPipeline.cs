using RocketBot.Rendering.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Rendering
{
	public class RenderPipeline : ICommandPipeline<IRenderCommand>
	{
		public List<IRenderCommand> Commands { get; } = new List<IRenderCommand>();

		public void ClearScreen()
		{
			Commands.Clear();
			Commands.Add(new ClearScreenCommand());
		}

		public IEnumerable<IRenderCommand> TakeCommands()
		{
			var commands = Commands.ToArray();
			Commands.Clear();
			return commands;
		}
	}
}
