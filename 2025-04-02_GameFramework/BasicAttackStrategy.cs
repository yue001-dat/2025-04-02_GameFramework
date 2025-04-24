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
	/// En basal angrebsstrategi, der vælger det første tilgængelige angreb.
	/// </summary>
	public class BasicAttackStrategy : IAttackStrategy
	{
		public int ChooseAttack(Creature attacker, Creature target)
		{
			if (attacker.AttackItems.Count > 0)
			{
				return attacker.AttackItems[0].GetDamage(attacker, target);
			}

			return 0;

		}
	}
}
