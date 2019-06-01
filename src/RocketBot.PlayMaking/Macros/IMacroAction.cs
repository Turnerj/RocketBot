using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Macros
{
	public interface IMacroAction
	{
		double PriorityMultiplier { get; set; }
		double GetActionPriority(WorldState worldState, int playerIndex);
		IEnumerable<IMicroAction> GetMicroActions(WorldState worldState, int playerIndex);
	}
}
