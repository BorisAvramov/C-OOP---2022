using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private int enduranceLevel ;

       
        protected MilitaryUnit(double cost)
        {
            Cost = cost;
            enduranceLevel = 1;
        }

        public int EnduranceLevel
        {
            get { return enduranceLevel; }
           private set { enduranceLevel = value; }
        }

        public double Cost { get; private set; }


        public void IncreaseEndurance()
        {
            if (EnduranceLevel + 1 > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);

            }
            else
            {
                EnduranceLevel += 1;
            }
        }

        public override string ToString()
        {
            return base.GetType().Name;
        }
    }
}
