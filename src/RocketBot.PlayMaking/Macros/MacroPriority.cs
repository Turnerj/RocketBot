using System;
using System.Collections.Generic;
using System.Text;

namespace RocketBot.Macros
{
	public struct MacroPriority
	{
		public IMacroAction Action { get; set; }
		public double Priority { get; set; }
	}
}
