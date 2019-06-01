using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace RocketBot.Macros
{
	//TODO: Need to add a debug renderer thing to this
	//		Display all actions with priority score over player
	//		At minimum, will need to tweak the priority for Boost Pickup
	//		May need to tweak the cooldown for it too
	//		Boost pickup should also factor in the angle to the boost - if it is behind you, maybe don't turn around to pick it up
	public class MacroManager
	{
		public int PlayerIndex { get; }
		public IEnumerable<IMacroAction> Actions { get; }

		public IMacroAction CurrentMacro { get; private set; }
		private IMicroAction CurrentMicro { get; set; }
		private Queue<IMicroAction> MicroActions { get; set; }

		private Stopwatch MacroActionWatch { get; } = new Stopwatch();
		private Stopwatch MicroActionWatch { get; } = new Stopwatch();

		private readonly static TimeSpan MinMacroTime = new TimeSpan(0, 0, 0, 0, 500);

		public MacroManager(int playerIndex, IEnumerable<IMacroAction> actions)
		{
			PlayerIndex = playerIndex;
			Actions = actions;
		}

		public IEnumerable<MacroPriority> GetMacrosByPriority(WorldState worldState)
		{
			return Actions.Select(
				a => new MacroPriority
				{
					Action = a,
					Priority = a.GetActionPriority(worldState, PlayerIndex) * a.PriorityMultiplier,
				}
			).OrderByDescending(a => a.Priority);
		}

		private IMicroAction GetBestAction(WorldState worldState)
		{
			//Find best macro
			var bestMacro = GetMacrosByPriority(worldState).FirstOrDefault().Action;
			if (CurrentMacro == null || (bestMacro != CurrentMacro && MacroActionWatch.Elapsed > MinMacroTime) || MicroActions.Count == 0)
			{
				MacroActionWatch.Restart();
				CurrentMacro = bestMacro;
				MicroActions = new Queue<IMicroAction>(bestMacro.GetMicroActions(worldState, PlayerIndex));
				CurrentMicro = MicroActions.Dequeue();
			}
			else if (MicroActionWatch.Elapsed > CurrentMicro.ActionTime)
			{
				//Check status of current micro action
				MicroActionWatch.Restart();
				CurrentMicro = MicroActions.Dequeue();
			}

			return CurrentMicro;
		}

		public Controller GetController(WorldState worldState)
		{
			return GetBestAction(worldState).Action(worldState, PlayerIndex);
		}
	}
}
