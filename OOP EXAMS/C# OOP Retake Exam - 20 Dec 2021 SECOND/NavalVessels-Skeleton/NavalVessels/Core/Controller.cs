using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;


        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }



        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (!captains.Any(c => c.FullName == selectedCaptainName))
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            captain.Vessels.Add(vessel);
            vessel.Captain = captain;

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel vesselAttack = vessels.FindByName(attackingVesselName);
            IVessel vesselDefend = vessels.FindByName(defendingVesselName);

            if (vesselAttack == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (vesselDefend == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";

            }

            if (vesselAttack.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (vesselDefend.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";

            }

            vesselAttack.Attack(vesselDefend);

            vesselAttack.Captain.IncreaseCombatExperience();
            vesselDefend.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {vesselDefend.ArmorThickness}.";

        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);

            if (captain != null)
            {
                return captain.Report();

            }
            else
            {
                return null;
            }

        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);


            if (captains.Contains(captain))
            {
                return $"Captain {fullName} is already hired.";
            }
            else
            {
                captains.Add(captain);
                return $"Captain {fullName} is hired.";
            }


        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.Models.Any(m => m.Name == name))
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            if (vesselType != "Battleship" && vesselType != "Submarine")
            {
                return $"Invalid vessel type.";
            }

            IVessel vessel = null;

            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            if (vesselType == "Submarine")
            {

                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }

            vessels.Add(vessel);

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            if (vessel.GetType().Name == "Battleship")
            {
                IBattleship batlleship = (IBattleship)vessels.FindByName(vesselName);
                batlleship.RepairVessel();
            }
            else
            {
                ISubmarine submairine = (ISubmarine)vessels.FindByName(vesselName);
                submairine.RepairVessel();
            }
            return $"Vessel {vesselName} was repaired.";

        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            if (vessel.GetType().Name == "Battleship")
            {
                IBattleship battleship = (IBattleship)vessels.FindByName(vesselName);
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";

            }
            else 
            {
                ISubmarine submairine = (ISubmarine)vessels.FindByName(vesselName);
                submairine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }



        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel != null)
            {
                return vessel.ToString();

            }
            else
            {
                return null;
            }
        }
    }
}
