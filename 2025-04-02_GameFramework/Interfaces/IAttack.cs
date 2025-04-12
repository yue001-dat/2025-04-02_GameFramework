using _2025_04_02_GameFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Interfaces
{
	/// <summary>
	/// Interface der repræsenterer et attack-item.
	/// </summary>
	public interface IAttack
	{
		int Damage { get; }
		int Range { get; }
		string Description { get; }
		int GetDamage(Creature attacker, Creature target);
	}
}
