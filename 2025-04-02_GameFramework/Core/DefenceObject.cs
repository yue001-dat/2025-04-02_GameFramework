using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Core
{
	/// <summary>
	/// Repræsenterer et defence-objekt.
	/// </summary>
	public class DefenceObject : WorldObject
	{
		public int DamageReduction { get; set; }

		public DefenceObject(Point position, bool isRemovable, string description, int damageReduction)
			: base(position, isRemovable, description)
		{
			DamageReduction = damageReduction;
		}
	}
}
