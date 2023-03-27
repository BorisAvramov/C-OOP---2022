using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository    planets;


        public Controller()
        {
            planets = new PlanetRepository();
        }



        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            IMilitaryUnit unit = null;

            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();

            }
            else if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();

            }

            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));

            }

            

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return $"{unitTypeName} added successfully to the Army of {planetName}!";

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }


            IWeapon weapon = null;

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);

            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);

            }



            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));

            }

            

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return $"{planetName} purchased {weaponTypeName}!";


        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = planets.FindByName(name);
            if (planet != null)
            {
                return $"Planet {name} is already added!";
            }
            IPlanet planetToAdd = new Planet(name, budget);
            planets.AddItem(planetToAdd);
            return $"Successfully added Planet: {name}";

        }

        public string ForcesReport()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name))
            {
                sb.AppendLine(planet.PlanetInfo().ToString());


            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet planet1 = planets.FindByName(planetOne);
            IPlanet planet2 = planets.FindByName(planetTwo);

            IPlanet winner = null;
            IPlanet losing = null;

            bool noOneWin = false;

            bool isplanet1haveNuclear = planet1.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");
            bool isplanet2haveNuclear = planet2.Weapons.Any(w => w.GetType().Name == "NuclearWeapon");

            if (planet1.MilitaryPower == planet2.MilitaryPower)
            {
                if ((isplanet1haveNuclear == true && isplanet2haveNuclear == true)||
                    (isplanet1haveNuclear == false && isplanet2haveNuclear == false))
                {
                    noOneWin = true;

                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);
                    return $"The only winners from the war are the ones who supply the bullets and the bandages!";

                }

                if (isplanet1haveNuclear == true && isplanet2haveNuclear == false)
                {

                    winner = planet1;
                    losing = planet2;
                    


                }
                if (isplanet1haveNuclear == false && isplanet2haveNuclear == true)
                {
                    winner = planet2;
                    losing = planet1;


                }



            }
            
            else if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                losing = planet2;
            }
            else if (planet1.MilitaryPower < planet2.MilitaryPower)
            {
                winner = planet2;
                losing = planet1;
            }

            if (winner == planet1)
            {
                planet1.Spend(planet1.Budget / 2.0);
                planet1.Profit(planet2.Budget / 2.0);
                planet2.Spend(planet2.Budget / 2.0);

                double sumForcesCost = planet2.Army.Sum(u => u.Cost);
                double sumWeaponPrices = planet2.Weapons.Sum(u => u.Price);

                double total = sumForcesCost + sumWeaponPrices;

                planet1.Profit(total);

                planets.RemoveItem(planet2.Name);

                return $"{planet1.Name} destructed {planet2.Name}!";
            }

            if (winner == planet2)
            {
                planet2.Spend(planet2.Budget / 2.0);
                planet2.Profit(planet1.Budget / 2.0);
                planet1.Spend(planet1.Budget / 2.0);

                double sumForcesCost = planet1.Army.Sum(u => u.Cost);
                double sumWeaponPrices = planet1.Weapons.Sum(u => u.Price);

                double total = sumForcesCost + sumWeaponPrices;

                planet2.Profit(total);

                planets.RemoveItem(planet1.Name);

                return $"{planet2.Name} destructed {planet1.Name}!";
            }
            return null;
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.NoUnitsFound));

            }

            planet.Spend(1.25);
            planet.TrainArmy();

            return $"{planetName} has upgraded its forces!";
        }
    }
}
