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
        private int combatExperience = 0;
        private List<IVessel> vessels;


        public Captain(string fullName)
        {
            vessels = new List<IVessel>();
            FullName = fullName;
        }


        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }


                fullName = value;
            }


        }

        public int CombatExperience { get { return combatExperience; } private set {  combatExperience = value ; } }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            if (!vessels.Contains(vessel))
            {
                vessels.Add(vessel);
            }



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
                foreach (var vessel in vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();

        }
    }
}
