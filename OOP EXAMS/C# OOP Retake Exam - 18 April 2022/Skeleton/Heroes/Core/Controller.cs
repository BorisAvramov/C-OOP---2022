using Heroes.Core.Contracts;
using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using Heroes.Models.Map;
using Heroes.Models.Weapons;
using Heroes.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {

        private HeroRepository heroes;
        private WeaponRepository weapons;


        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(h=>h.Name == heroName))
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if (!weapons.Models.Any(w=>w.Name == weaponName))
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }

            IHero hero = heroes.Models.FirstOrDefault(h=>h.Name == heroName);
            IWeapon weapon = weapons.Models.FirstOrDefault(w=>w.Name == weaponName);

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return $"Hero {heroName} can participate in battle using a {weapon.GetType().Name.ToLower()}.";

        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if (type != "Knight" && type != "Barbarian")
            {
                throw new InvalidOperationException("Invalid hero type.");
            }
            if (heroes.Models.Any(m => m.Name == name))
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }

            IHero hero = null;

            if (type == "Knight")
            {
                hero = new Knight(name, health, armour);

            }
            else
            {
                hero = new Barbarian(name, health, armour);
            }

            heroes.Add(hero);

            return hero is Knight ? $"Successfully added Sir {name} to the collection." : $"Successfully added Barbarian {name} to the collection.";
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (type != "Mace" && type != "Claymore")
            {
                throw new InvalidOperationException("Invalid weapon type.");
            }
            if (weapons.Models.Any(m => m.Name == name))
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }

            IWeapon weapon = null;

            if (type == "Mace")
            {
                weapon = new Mace (name, durability);

            }
            else
            {
                weapon = new Claymore(name, durability);
            }

            weapons.Add(weapon);

            return $"A {weapon.GetType().Name.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {

            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes.Models.OrderBy(h => h.GetType().Name).OrderByDescending(h=>h.Health).OrderBy(h=>h.Name))
            {

                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");
                string result = hero.Weapon != null ? hero.Weapon.Name : "Unarmed";
                sb.AppendLine($"--Weapon: {result}");

            }

            return sb.ToString().TrimEnd();
        }

        public string StartBattle()
        {
            IMap map = new Map();

            List<IHero> heroesAliveWithWeapon = new List<IHero>();

            foreach (IHero hero in heroes.Models)
            {
                if (hero.Health > 0 && hero.Weapon != null)
                {
                    heroesAliveWithWeapon.Add(hero);
                }
            }


            return map.Fight(heroesAliveWithWeapon);

            
        }
    }
}
