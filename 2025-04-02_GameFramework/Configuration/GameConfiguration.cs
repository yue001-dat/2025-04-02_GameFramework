using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2025_04_02_GameFramework.Configuration
{
	/// <summary>
	/// Specificerer spillets sværhedsgrad.
	/// </summary>
	public enum GameLevel
	{
		Novice,
		Normal,
		Trained
	}

	/// <summary>
	/// Repræsenterer konfigurationsindstillinger for spillet.
	/// </summary>
	public class GameConfiguration
	{
		public int WorldWidth { get; set; }
		public int WorldHeight { get; set; }
		public GameLevel Level { get; set; }
	}
}
