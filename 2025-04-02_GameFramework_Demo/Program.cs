using System;
using _2025_04_02_GameFramework;
using _2025_04_02_GameFramework.Configuration;
using _2025_04_02_GameFramework.Core;
using _2025_04_02_GameFramework.Logging;

namespace GameDemo
{
	class Program
    {
        static void Main(string[] args)
        {
            // Loggging
            Logger.AddListener(new ConsoleTraceListener());

            // Config
            GameConfiguration config = null;

            try
            {
                config = ConfigurationLoader.LoadConfiguration("C:\\Users\\Yusuf\\source\\repos\\2025-04-02_GameFramework\\2025-04-02_GameFramework_Demo\\GameConfig.xml");
            }
            catch (Exception ex)
            {
                Logger.Log("Error loading configuration: " + ex.Message);
                return;
            }

            // Opret verden
            World world = new World(config.WorldWidth, config.WorldHeight);

			// Opret creatures
			Creature warrior = new Warrior("Conan", 100, new Point(10, 10));
            Creature mage = new Mage("Merlin", 80, new Point(15, 15));

            world.AddCreature(warrior);
            world.AddCreature(mage);

            // Opret et attack-objekt (sværd)
            AttackObject sword = new AttackObject(15, 1, "Sword");
     
			// og tilføj som tilføj det som et bonus-objekt i verdenen.
			world.AddObject(new BonusObject(new Point(10, 10), true, "Sword Bonus", sword));

            // Opret et defence-objekt (skjold) og tilføj det til verdenen.
            DefenceObject shield = new DefenceObject(new Point(15, 15), true, "Shield", 5);
            world.AddObject(shield);

            // Tilføj eventuelt et dekoreret (boostet) attack-item til warrior.
            var boostedSword = new AttackDecorator(sword, 5);
            warrior.AttackItems.Add(boostedSword);

            // Tilføj eventuelt et composite attack-item (kombinerer en dolk og en økse) til warrior.
            AttackComposite compositeAttack = new AttackComposite();
            compositeAttack.AddAttack(new AttackObject(5, 1, "Dagger"));
            compositeAttack.AddAttack(new AttackObject(10, 1, "Axe"));
            warrior.AttackItems.Add(compositeAttack);

            // Simuler en tur for hver creature.
            foreach (var creature in world.Creatures)
            {
                creature.PerformTurn(world);
            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
