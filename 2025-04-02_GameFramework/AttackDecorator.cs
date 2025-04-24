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
	/// Decorator for attack-objekter, som booster angrebsdamagen.
	/// </summary>
	public class AttackDecorator : AttackObject // IAttact istedet for AttackObject selvom den er implementeret i AttackObject.
	{
		private readonly IAttack _innerAttack;
		private readonly int _bonusDamage;

		public AttackDecorator(IAttack innerAttack, int bonusDamage)
			: base(innerAttack.Damage, innerAttack.Range, innerAttack.Description)
		{
			_innerAttack = innerAttack;
			_bonusDamage = bonusDamage;
			Description = innerAttack.Description + " [Boosted]";
		}

		public override int GetDamage(Creature attacker, Creature target)
		{
			int baseDamage = _innerAttack.GetDamage(attacker, target);
		
			return baseDamage + _bonusDamage;
		}
	}
}
