using _2025_04_02_GameFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Core
{
	/// <summary>
	/// Repræsenterer spillets verden.
	/// </summary>
	public class World
	{
		public int Width { get; }
		public int Height { get; }
		public List<Creature> Creatures { get; } = new List<Creature>();
		public List<WorldObject> Objects { get; } = new List<WorldObject>();

		public World(int width, int height)
		{
			Width = width;
			Height = height;
			Logger.Log($"World created with size {width}x{height}");
		}

		/// <summary>
		/// Finder en creature baseret på navn ved brug af LINQ.
		/// </summary>
		public Creature GetCreatureByName(string name)
		{
			return Creatures.FirstOrDefault(c => c.Name == name);
		}

		public void AddCreature(Creature creature)
		{
			Creatures.Add(creature);
			Logger.Log($"Creature {creature.Name} added to the world at {creature.Position}");
		}

		public void AddObject(WorldObject obj)
		{
			Objects.Add(obj);
			Logger.Log($"Object {obj.Description} added to the world at {obj.Position}");
		}
	}
}
