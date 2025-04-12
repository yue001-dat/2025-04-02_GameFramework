using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _2025_04_02_GameFramework.Configuration
{
	/// <summary>
	/// Indlæser spilkonfigurationen fra en XML-fil.
	/// </summary>
	public static class ConfigurationLoader
	{
		public static GameConfiguration LoadConfiguration(string filePath)
		{
			if (!File.Exists(filePath))
				throw new FileNotFoundException($"Configuration file not found: {filePath}");

			XDocument doc = XDocument.Load(filePath);
			var configElement = doc.Element("GameConfiguration");
			if (configElement == null)
				throw new Exception("Invalid configuration file format.");

			GameConfiguration config = new GameConfiguration
			{
				WorldWidth = int.Parse(configElement.Element("WorldWidth")?.Value ?? "100"),
				WorldHeight = int.Parse(configElement.Element("WorldHeight")?.Value ?? "100"),
				Level = Enum.TryParse(configElement.Element("GameLevel")?.Value, out GameLevel level) ? level : GameLevel.Normal
			};

			return config;
		}
	}
}
