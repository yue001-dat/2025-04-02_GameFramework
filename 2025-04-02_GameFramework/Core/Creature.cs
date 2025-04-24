using _2025_04_02_GameFramework.Interfaces;
using _2025_04_02_GameFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Core
{
	/// <summary>
	/// Abstrakt baseklasse, der repræsenterer en creature i spillet.
	/// </summary>
	public abstract class Creature
	{
		public string Name { get; set; }
		public int HitPoints { get; set; }
		public Point Position { get; set; }
		public List<IAttack> AttackItems { get; } = new List<IAttack>();
		public List<DefenceObject> DefenceItems { get; } = new List<DefenceObject>();

		/// <summary>
		/// Event der udløses, når creature modtager et hit.
		/// </summary>
		public event EventHandler<int> OnHit;

		/// <summary>
		/// Angrebsstrategi for creaturen.
		/// </summary>
		public IAttackStrategy AttackStrategy { get; set; }

		protected Creature(string name, int hitPoints, Point position)
		{
			Name = name;
			HitPoints = hitPoints;
			Position = position;
			Logger.Log($"Creature {Name} created at position {Position} with {HitPoints} hit points.");
		}

		/// <summary>
		/// Template-metode for creaturens tur.
		/// </summary>
		public void PerformTurn(World world)
		{
			Logger.Log($"{Name} is taking its turn.");
			PreTurn();
			ExecuteTurn(world);
			PostTurn();
		}

		protected virtual void PreTurn()
		{
			// Fælles handlinger før turen.
			Logger.Log($"{Name} is preparing for the turn.");
		}

		/// <summary>
		/// Abstrakt metode til at udføre turens logik.
		/// </summary>
		protected abstract void ExecuteTurn(World world);

		protected virtual void PostTurn()
		{
			// Fælles handlinger efter turen.
			Logger.Log($"{Name} has finished its turn.");
		}

		/// <summary>
		/// Udfører et hit på en anden creature ved brug af en angrebsstrategi eller et standard attack-item.
		/// </summary>
		public void Hit(Creature target)
		{
			if (AttackStrategy != null)
			{
				int damage = AttackStrategy.ChooseAttack(this, target);
				Logger.Log($"{Name} attacks {target.Name} with strategy causing {damage} damage.");
				target.ReceiveHit(damage);
			}
			else if (AttackItems.Count > 0)
			{
				int damage = AttackItems[0].GetDamage(this, target);
				Logger.Log($"{Name} attacks {target.Name} with {AttackItems[0].Description} causing {damage} damage.");
				target.ReceiveHit(damage);
			}
			else
			{
				Logger.Log($"{Name} has no attack items to use.");
			}
		}

		/// <summary>
		/// Modtager skade fra et hit og notifikere observers.
		/// </summary>
		public virtual void ReceiveHit(int damage)
		{
			int totalReduction = 0;
			foreach (var defence in DefenceItems)
			{
				totalReduction += defence.DamageReduction;
			}

			int actualDamage = Math.Max(0, damage - totalReduction);

			HitPoints -= actualDamage;

			Logger.Log($"{Name} received {actualDamage} damage after defence. Remaining hit points: {HitPoints}");

			OnHit?.Invoke(this, actualDamage);

			if (HitPoints <= 0)
			{
				Logger.Log($"{Name} has died.");
			}
		}

		/// <summary>
		/// Henter et world-objekt.
		/// </summary>
		public virtual void Loot(WorldObject obj)
		{
			Logger.Log($"{Name} loots object {obj.Description} at position {obj.Position}");
			if (obj is IAttack attack)
			{
				AttackItems.Add(attack);
			}
			else if (obj is DefenceObject defence)
			{
				DefenceItems.Add(defence);
			}
		}
	}
}
