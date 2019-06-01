using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Server
{
	public class EnvironmentInitializedEventArgs : EventArgs
	{
		public string DllDirectory { get; }

		public EnvironmentInitializedEventArgs(string dllDirectory)
		{
			DllDirectory = dllDirectory;
		}
	}
}
