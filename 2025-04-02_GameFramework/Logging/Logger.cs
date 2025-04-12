using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Logging
{
	/// <summary>
	/// En simpel logger, der understøtter trace-meddelelser.
	/// </summary>
	public static class Logger
	{
		public static List<ITraceListener> TraceListeners { get; } = new List<ITraceListener>();

		public static void Log(string message)
		{
			foreach (var listener in TraceListeners)
			{
				listener.WriteLine(message);
			}
		}

		public static void AddListener(ITraceListener listener)
		{
			if (!TraceListeners.Contains(listener))
				TraceListeners.Add(listener);
		}

		public static void RemoveListener(ITraceListener listener)
		{
			if (TraceListeners.Contains(listener))
				TraceListeners.Remove(listener);
		}
	}

	/// <summary>
	/// Interface for trace-lyttere.
	/// </summary>
	public interface ITraceListener
	{
		void WriteLine(string message);
	}
}
