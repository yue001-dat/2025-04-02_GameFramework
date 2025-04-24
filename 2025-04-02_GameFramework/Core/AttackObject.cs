using _2025_04_02_GameFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Core
{
	/// <summary>
	/// Repræsenterer et attack-objekt.
	/// </summary>
	public class AttackObject : IAttack
	{
		public int Damage { get; protected set; }
		public int Range { get; protected set; }
		public string Description { get; protected set; }

		public AttackObject(int damage, int range, string description)
		{
			Damage = damage;
			Range = range;
			Description = description;
		}

		public virtual int GetDamage(Creature attacker, Creature target)
		{
			return Damage;
		}
	}
}
