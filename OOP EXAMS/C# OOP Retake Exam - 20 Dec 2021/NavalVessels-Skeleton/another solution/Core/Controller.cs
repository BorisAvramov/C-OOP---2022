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
        private VesselRepository vessels = new VesselRepository();
        private ICollection<ICaptain> captains = new List<ICaptain>();
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            var vessel = vessels.FindByName(selectedVesselName);
            if(vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if(vessel.Captain.FullName != "default")
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            else
            {
                vessel.Captain = captain;
                captain.AddVessel(vessel);
                return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.FindByName(attackingVesselName);
            var defendingVessel = vessels.FindByName(defendingVesselName);
            if(attackingVessel == null || defendingVessel == null)
            {
                if (attackingVessel == null)
                {
                    return $"Vessel {attackingVesselName} could not be found.";
                }
                else
                {
                    return $"Vessel {defendingVessel} could not be found.";
                }
            }

            if (attackingVessel.ArmorThickness == 0 || defendingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }


            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.First(c => c.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            var captain = new Captain(fullName);
            if (this.captains.FirstOrDefault(c => c.FullName == fullName) != null)
            {
                return $"Captain {fullName} is already hired."; //0000
            }
            else
            {
                captains.Add(captain);
                return $"Captain {fullName} is hired.";
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vessels.FindByName(name) != null)
            {
                return $"{vesselType} vessel {name} is already manufactured.";
            }
            if(vesselType != "Battleship" && vesselType != "Submarine")
            {
                return "Invalid vessel type.";
            }

            Vessel vessel = null;
            if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
                vessels.Add(vessel);
                return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
            }
            else
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
                vessels.Add(vessel);
                return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
            }
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            if(vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            vessel.RepairVessel();
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
                Battleship battleshipCast = (Battleship)vessel;
                //Battleship myVessel = (Battleship)vessels.FindByName(vesselName);
                battleshipCast.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                Submarine submarineCast = (Submarine)vessel;
                //Submarine myVessel = (Submarine)vessels.FindByName(vesselName);
                submarineCast.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);
            return vessel.ToString();
        }
    }
}
