using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Macros
{
	public interface IMicroAction
	{
		TimeSpan ActionTime { get; set; }
		Func<WorldState, int, Controller> Action { get; set; }
	}
}
