using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_04_02_GameFramework.Interfaces
{
	public interface IAttackItem
	{
		int HitPoints { get; }
		int Range { get; }
		string Description { get; }
		int CalculateDamage();
	}
}
