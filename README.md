# RocketBot

A .NET interface for writing your very own Rocket League bot. This implementation is heavily inspired by [RLBot](https://github.com/RLBot/RLBot) and uses the same Python interface.
While RLBot also has a .NET implementation, this implementation is re-written from the ground up to be easier to use.

## Features

- Built in .NET Standard, allowing bots to target .NET Core and all that it brings (eg. performance improvements)
- Easier to use interfaces with no `.Value` calls required
- A "Render Pipeline" that allows staging of rendering commands

## Requirements

Make sure you've installed [Python 3.6 64 bit](https://www.python.org/ftp/python/3.6.5/python-3.6.5-amd64.exe). During installation:
 - Select "Add Python to PATH"
 - Make sure pip is included in the installation

## Example Bot
This bot is functionally the same as the example bot that RLBot provides for its .NET example. As you can see, the interfaces are similar if you are used to RLBot.

```csharp
class ExampleBot : RocketBotBase
{
	public ExampleBot(string name, int team, int player) : base(name, team, player) { }

	public override Controller OnTick(WorldState worldState, IEnumerable<BallPredictionSlice> ballPrediction)
	{
		var controller = new Controller();

		var ballLocation = worldState.Ball.Physics.Location;
		var carPhysics = worldState.Players[PlayerIndex].Physics;
		var carLocation = carPhysics.Location;
		var carRotation = carPhysics.Rotation;

		var botToTargetAngle = Math.Atan2(ballLocation.Y - carLocation.Y, ballLocation.X - carLocation.X);
		var botFrontToTargetAngle = botToTargetAngle - carRotation.Yaw;
		// Correct the angle
		if (botFrontToTargetAngle < -Math.PI)
			botFrontToTargetAngle += 2 * Math.PI;
		if (botFrontToTargetAngle > Math.PI)
			botFrontToTargetAngle -= 2 * Math.PI;

		// Decide which way to steer in order to get to the ball.
		if (botFrontToTargetAngle > 0)
			controller.Steer = 1;
		else
			controller.Steer = -1;

		controller.Throttle = 1;

		return controller;
	}
}
```

## RocketBot.PlayMaking

The goal of RocketBot wasn't to just remake RLBot but to provide a more powerful and easier to use mechanism to write a bot. While the main library "RocketBot" is equivalent to RLBot's 
.NET implementation, the goal is to provide a "play making" API for easier control over the bot. This will form an optional library called "RocketBot.PlayMaking".

Planned features include:
- Movement calculation helpers (eg. calculate the optimal yaw for a vehicle)
- Inter-bot communication (allowing a team of bots to co-ordinate actions)
- Macro and Micro actions (eg. "move to X when Y", "get boost when X", "demo player" - these are so you don't need to do the math yourself)

Note: These features are NOT available yet, just what is planned through RocketBot.