using System;
using System.Collections.Generic;
using System.Text;
using RocketBot.Model;

namespace RocketBot.AI.Goals
{
	public class Attack : IGoal
	{
		public double GetPriority(int playerIndex, WorldState worldState)
		{
			//worldState.Ball
			return 0;
		}
	}
}
