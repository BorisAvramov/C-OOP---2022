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
            if (!vessels.Models.Any(v => v.Name == selectedVesselName))
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            IVessel vessel = vessels.FindByName(selectedVesselName);
            if (vessel.Captain.FullName != "default")
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }

            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel vesselAttacking = vessels.FindByName(attackingVesselName);
            IVessel vesselDefending = vessels.FindByName(defendingVesselName);
            if (vesselAttacking == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }


            if (vesselDefending == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            if (vesselAttacking.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (vesselDefending.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";

            }


            vesselAttacking.Attack(vesselDefending);
            vesselAttacking.Captain.IncreaseCombatExperience();
            vesselDefending.Captain.IncreaseCombatExperience();
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName}current armor thickness: {vesselDefending.ArmorThickness}.";

        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);

            return captain.Report();


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
          

            IVessel vessel = null;
            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }

            if (vessels.Models.Contains(vessel))
            {
                return $"{vessel.GetType().Name} vessel {name} is already manufactured.";
            }
            if (vesselType != "Battleship" && vesselType != "Submarine")
            {
                return "Invalid vessel type.";
            }
            vessels.Add(vessel);

            return $"{vessel.GetType().Name} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();

            //if (vessel.GetType().Name == "Battleship")
            //{
            //    IBattleship battle = vessels.Models.FirstOrDefault(v => v.Name == vesselName) as IBattleship;
            //    battle.RepairVessel();

            //}
            //else if (vessel.GetType().Name == "Submarine")
            //{
            //    ISubmarine submarine = vessels.Models.FirstOrDefault(v => v.Name == vesselName) as ISubmarine;
            //    submarine.RepairVessel();
            //}


          
            return $"Vessel {vesselName} was repaired.";

        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
           
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            if (vessel is Battleship)
            {
               
                IBattleship battleShip = vessels.Models.FirstOrDefault(v => v.Name == vesselName) as IBattleship;
                battleShip.ToggleSonarMode();
               
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            if (vessel is Submarine)
            {
                ISubmarine submarine = vessels.Models.FirstOrDefault(v => v.Name == vesselName) as ISubmarine;
                submarine.ToggleSubmergeMode();

                return $"Submarine {vesselName} toggled submerge mode.";
            }

            return null;

            //IVessel vessel = vessels.FindByName(vesselName);
            //if (vessel == null)
            //{
            //    return $"Vessel {vesselName} could not be found.";
            //}

            //if (vessel.GetType().Name == "Battleship")
            //{
            //    Battleship battleshipCast = (Battleship)vessel;
            //    //Battleship myVessel = (Battleship)vessels.FindByName(vesselName);
            //    battleshipCast.ToggleSonarMode();
            //    return $"Battleship {vesselName} toggled sonar mode.";
            //}
            //else
            //{
            //    Submarine submarineCast = (Submarine)vessel;
            //    //Submarine myVessel = (Submarine)vessels.FindByName(vesselName);
            //    submarineCast.ToggleSubmergeMode();
            //    return $"Submarine {vesselName} toggled submerge mode.";
            //}

        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString();

        }
    }
}
