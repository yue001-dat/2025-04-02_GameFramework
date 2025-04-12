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
	/// Composite-mønsteret til at kombinere flere attack-items.
	/// </summary>
	public class AttackComposite : IAttack
	{
		private readonly List<IAttack> _attacks = new List<IAttack>();

		public int Damage => _attacks.Sum(a => a.Damage);
		public int Range => _attacks.Any() ? _attacks.Max(a => a.Range) : 0;
		public string Description => "Composite Attack: " + string.Join(", ", _attacks.Select(a => a.Description));

		public void AddAttack(IAttack attack)
		{
			_attacks.Add(attack);
		}

		public int GetDamage(Creature attacker, Creature target)
		{
			// Summer skaden fra alle angreb.
			return _attacks.Sum(a => a.GetDamage(attacker, target));
		}
	}
}
