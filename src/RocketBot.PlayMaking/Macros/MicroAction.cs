using RocketBot.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Macros
{
	public class MicroAction : IMicroAction
	{
		public TimeSpan ActionTime { get; set; }
		public Func<WorldState, int, Controller> Action { get; set; }

		/// <summary>
		/// Generates a collection of <see cref="MicroAction"/> instances for a given millisecond frequency across a span of time.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="frequency"></param>
		/// <param name="totalTime"></param>
		/// <returns></returns>
		public static IEnumerable<MicroAction> FrequentAction(Func<WorldState, int, Controller> action, int frequency, TimeSpan totalTime)
		{
			var numberOfActions = totalTime.TotalMilliseconds / frequency;

			for (var i = 0; i < numberOfActions; i++)
			{
				yield return new MicroAction
				{
					Action = action,
					ActionTime = new TimeSpan(0, 0, 0, 0, frequency)
				};
			}
		}
	}
}
