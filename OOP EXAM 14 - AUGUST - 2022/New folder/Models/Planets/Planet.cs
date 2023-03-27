using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {

        private readonly UnitRepository units;
        private readonly WeaponRepository weapons;

        private string name;
        private double budget;


        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
           
        }


        public double MilitaryPower => CalcMilitaryPower(units, weapons);
     

        private double CalcMilitaryPower( UnitRepository units, WeaponRepository weapons)
        {
            double sumUnitEndurances = units.Models.Sum(u => u.EnduranceLevel);
            double sumWeaponDestructionLevel = weapons.Models.Sum(w => w.DestructionLevel);

            double totamAmount = sumUnitEndurances + sumWeaponDestructionLevel;

            if (units.Models.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                totamAmount += (totamAmount * 0.3);
            }
            if (weapons.Models.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                totamAmount += (totamAmount * 0.45);
            }

           var militaryPower = Math.Round(totamAmount, 3);
            return militaryPower;
        }

        public double Budget 
        {
            get { return budget ; }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget  = value;
            }
        }


        public string Name
        {
            get { return name; }
           private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value; 
            
            }
        }








        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);

           
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);

        }

        public string PlanetInfo()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            string resultUnts = string.Join(", ", units.Models);
            string result = units.Models.Count > 0 ? $"{resultUnts}" : "No units";
            sb.AppendLine($"--Forces: {result}");
            string resultweapons = string.Join(", ", weapons.Models);
            string result2 = weapons.Models.Count > 0 ?  resultweapons: "No weapons";

            sb.AppendLine($"--Combat equipment: {result2}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();

        }

        public void Profit(double amount)
        {
            Budget += amount;

        }

        public void Spend(double amount)
        {
            if (amount > Budget)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in units.Models)
            {
                unit.IncreaseEndurance();


            }
        }
    }
}
