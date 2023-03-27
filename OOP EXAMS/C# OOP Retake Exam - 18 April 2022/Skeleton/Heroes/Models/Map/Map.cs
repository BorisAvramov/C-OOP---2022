using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<Barbarian> barbarianList = new List<Barbarian>();
            List<Knight> knightList = new List<Knight>();

            foreach (IHero hero in players) 
            {
                if (hero is Barbarian)
                {
                    barbarianList.Add(hero as Barbarian);
                }
                if (hero is Knight)
                {
                    knightList.Add(hero as Knight);
                }
            
            }

            bool knightWin = false;
            bool barbarianWin = false;

            int deathKnights = 0;
            int deadBarbarians = 0;

            int countAttack = 0;

            while (true)
            {
                countAttack++;

                if (!barbarianList.Any(h => h.Health > 0))
                {
                    knightWin = true;
                    break;

                }

                if (!knightList.Any(h => h.Health > 0))
                {
                    barbarianWin = true;
                    break;

                }

                if (countAttack % 2 != 0)
                {
                    foreach (var knight in knightList.Where(k => k.Health > 0))
                    {
                        foreach (var barabrian in barbarianList.Where(b => b.Health > 0))
                        {

                            barabrian.TakeDamage(knight.Weapon.DoDamage());

                            if (barabrian.Health <= 0)
                            {
                                deadBarbarians++;
                            }

                        }

                    }


                }
                else if (countAttack % 2 == 0)
                {
                    foreach (var barbarian in barbarianList.Where(k => k.Health > 0))
                    {
                        foreach (var knight in knightList.Where(b => b.Health > 0))
                        {

                            knight.TakeDamage(barbarian.Weapon.DoDamage());

                            if (knight.Health <= 0)
                            {
                                deathKnights++;
                            }

                        }

                    }


                }


              

            }

            if (knightWin)
            {
                return $"The knights took {deathKnights} casualties but won the battle.";
            }
            if (barbarianWin)
            {
                return $"The barbarians took {deadBarbarians} casualties but won the battle.";
            }

            return null;
        }
    }
}
