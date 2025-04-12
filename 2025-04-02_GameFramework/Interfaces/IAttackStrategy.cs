using _2025_04_02_GameFramework.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Interfaces
{
	/// <summary>
	/// Interface for angrebsstrategier.
	/// </summary>
	public interface IAttackStrategy
	{
		int ChooseAttack(Creature attacker, Creature target);
	}
}
