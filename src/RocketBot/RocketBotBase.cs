using rlbot.flat;
using RocketBot.Model;
using RocketBot.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot
{
	public abstract class RocketBotBase
	{
		public string Name { get; }
		public int Team { get; }
		public int PlayerIndex { get; }

		public RocketBotBase(string name, int team, int playerIndex)
		{
			Name = name;
			Team = team;
			PlayerIndex = playerIndex;
		}

		public abstract Controller OnTick(WorldState worldState, IEnumerable<BallPredictionSlice> ballPrediction);

		public RenderPipeline RenderPipeline { get; private set; }

		internal void SetRenderPipeline(RenderPipeline renderPipeline)
		{
			RenderPipeline = renderPipeline;
		}
	}
}
