using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private List<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            combatExperience = 0;
            vessels = new List<IVessel>();
        }

        public int CombatExperience 
        {
            get { return combatExperience; }
            private set 
            {
                //if (value > 10)
                //{
                //    combatExperience = 10;
                //}
                //combatExperience = value; 
                combatExperience = value;
            }
        }


        public string FullName
        {
            get { return fullName; }
            private set 
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidCaptainName));
                }
                fullName = value;
            
            }
        }


        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidVesselForCaptain));
            }

            vessels.Add(vessel);

        }

        public void IncreaseCombatExperience()
        {
            combatExperience += 10;

        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if (vessels.Any())
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            return sb.ToString().TrimEnd();

        }
    }
}
