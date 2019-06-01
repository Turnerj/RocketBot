using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.AI
{
	public class TeamEngine
	{
		private static ConcurrentDictionary<int, TeamState> TeamStates { get; } = new ConcurrentDictionary<int, TeamState>();

		public int PlayerIndex { get; }
		public int Team { get; }

		public static TeamEngine JoinTeam(int playerIndex, int team)
		{
			var teamState = new TeamState();
			teamState.AddPlayer(playerIndex);

			TeamStates.AddOrUpdate(team, teamState, (existingTeam, existingTeamState) =>
			{
				existingTeamState.AddPlayer(playerIndex);
				return existingTeamState;
			});

			return new TeamEngine(playerIndex, team);
		}

		private TeamEngine(int playerIndex, int team)
		{
			PlayerIndex = playerIndex;
			Team = team;
		}
	}
}
