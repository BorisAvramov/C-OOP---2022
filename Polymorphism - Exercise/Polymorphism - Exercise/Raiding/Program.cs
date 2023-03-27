using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {


            int intValue = int.Parse(Console.ReadLine());

          

            List<IRidingGroup> raidingHeroes = new List<IRidingGroup>();

            for (int i = 0; i < intValue; i++)
            {

                string name = Console.ReadLine();
                string Type = Console.ReadLine();

                if (Type != "Druid" && Type != "Paladin" && Type != "Rogue" && Type != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;

                }

                if (Type == "Druid")
                {
                    Druid druid = new Druid(name);
                    raidingHeroes.Add(druid);
                }
                else if (Type == "Paladin")
                {
                    Paladin paladin = new Paladin(name);
                    raidingHeroes.Add(paladin);
                }
                else if (Type == "Rogue")
                {
                    Rogue rogue = new Rogue(name);
                    raidingHeroes.Add(rogue);
                }
                else if (Type == "Warrior")
                {
                    Warrior warrior = new Warrior(name);
                    raidingHeroes.Add(warrior);
                }
              
            }

            int bossPow = int.Parse(Console.ReadLine());

            int heroesPow = 0;
            foreach (var heroe in raidingHeroes)
            {
                heroesPow += heroe.Power;
                Console.WriteLine( heroe.CastAbility());
            }

            if (heroesPow >= bossPow)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
