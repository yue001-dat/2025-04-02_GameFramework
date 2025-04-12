using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Logging
{
	/// <summary>
	/// En simpel trace-lytter, der skriver log-meddelelser til konsollen.
	/// </summary>
	public class ConsoleTraceListener : ITraceListener
	{
		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}
