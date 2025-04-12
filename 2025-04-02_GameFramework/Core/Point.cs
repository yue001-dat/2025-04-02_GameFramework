using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Core
{
	/// <summary>
	/// Repræsenterer et punkt i 2D-rum, x y
	/// </summary>
	public struct Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public override string ToString() => $"({X}, {Y})";
	}
}
