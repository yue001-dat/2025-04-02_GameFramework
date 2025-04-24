using _2025_04_02_GameFramework.Core;
using _2025_04_02_GameFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework
{
	/// <summary>
	/// En konkret creature, en warrior.
	/// </summary>
	public class Warrior : Creature
	{
		public Warrior(string name, int hitPoints, Point position)
			: base(name, hitPoints, position)
		{
			// Sæt en standard angrebsstrategi.
			AttackStrategy = new BasicAttackStrategy();
		}

		protected override void ExecuteTurn(World world)
		{
		
			Creature target = null;

			foreach (var creature in world.Creatures)
			{
				if (creature != this)
				{
					target = creature;
					break;
				}
			}

			if (target != null)
			{
				Hit(target);
			}
			else
			{
				Logger.Log($"{Name} finds no target to attack.");
			}
		}
	}
}
