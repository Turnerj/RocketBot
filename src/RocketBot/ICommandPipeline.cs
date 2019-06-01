using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot
{
	public interface ICommandPipeline<TCommand>
	{
		List<TCommand> Commands { get; }
		IEnumerable<TCommand> TakeCommands();
	}
}
