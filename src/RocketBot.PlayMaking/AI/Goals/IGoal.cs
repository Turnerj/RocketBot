using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.AI.Goals
{
	public interface IGoal
	{
		double GetPriority(int playerIndex, WorldState worldState);
	}
}
