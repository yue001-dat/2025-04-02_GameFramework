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
	/// En konkret creature, en mage.
	/// </summary>
	public class Mage : Creature
	{
		public Mage(string name, int hitPoints, Point position)
			: base(name, hitPoints, position)
		{
			AttackStrategy = new BasicAttackStrategy();
		}

		protected override void ExecuteTurn(World world)
		{
			// Mage henter eventuelle objekter på sin nuværende position.
			foreach (var obj in world.Objects)
			{
				if (obj.Position.X == Position.X && obj.Position.Y == Position.Y)
				{
					Loot(obj);
				}
			}
			// Herefter angribes en enemy creature.
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
