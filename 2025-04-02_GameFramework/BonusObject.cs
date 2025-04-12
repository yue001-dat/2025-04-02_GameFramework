using _2025_04_02_GameFramework.Core;
using _2025_04_02_GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework
{
	/// <summary>
	/// Et bonus-objekt, der kan indeholde et attack-item.
	/// </summary>
	public class BonusObject : WorldObject
	{
		public IAttack AttackItem { get; set; }

		public BonusObject(Point position, bool isRemovable, string description, IAttack attackItem)
			: base(position, isRemovable, description)
		{
			AttackItem = attackItem;
		}
	}
}
