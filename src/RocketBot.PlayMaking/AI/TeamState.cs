using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;
using System.Linq;

namespace RocketBot.AI
{
	public class TeamState
	{
		private ConcurrentDictionary<int, ConcurrentStack<IPlayerMessage>> Players { get; } = new ConcurrentDictionary<int, ConcurrentStack<IPlayerMessage>>();

		internal void AddPlayer(int playerIndex)
		{
			Players.TryAdd(playerIndex, new ConcurrentStack<IPlayerMessage>());
		}

		internal void MessagePlayer(int playerIndex, IPlayerMessage message)
		{
			if (Players.TryGetValue(playerIndex, out var messageStack))
			{
				messageStack.Push(message);
			}
		}


		internal IEnumerable<IPlayerMessage> TakeMessages(int playerIndex)
		{
			if (Players.TryGetValue(playerIndex, out var messageStack))
			{
				var messages = messageStack.ToArray();
				messageStack.Clear();
				return messages;
			}

			return Enumerable.Empty<IPlayerMessage>();
		}
	}
}
