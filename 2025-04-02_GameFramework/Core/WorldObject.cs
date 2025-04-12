using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Core
{
	/// <summary>
	/// Repræsenterer et objekt i spillets verden.
	/// </summary>
	public abstract class WorldObject
	{
		public Point Position { get; set; }
		public bool IsRemovable { get; set; }
		public string Description { get; set; }

		protected WorldObject(Point position, bool isRemovable, string description)
		{
			Position = position;
			IsRemovable = isRemovable;
			Description = description;
		}
	}
}
