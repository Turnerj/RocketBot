namespace RocketBot
{
	/// <summary>
	/// A struct that represents the outputs that the bot should perform.
	/// </summary>
	public class Controller
	{
		public float Throttle { get; set; }
		/// <summary>
		/// Steering values are between -1 and 1
		/// </summary>
		public float Steer { get; set; }
		public float Pitch { get; set; }
		public float Yaw { get; set; }
		public float Roll { get; set; }
		public bool Jump { get; set; }
		public bool Boost { get; set; }
		public bool Handbrake { get; set; }
	}
}
