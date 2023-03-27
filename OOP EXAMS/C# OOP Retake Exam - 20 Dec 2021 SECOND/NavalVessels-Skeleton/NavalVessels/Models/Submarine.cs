using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode = false;


        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {


        }

        public bool SubmergeMode => submergeMode;

        public override void RepairVessel()
        {
            if (ArmorThickness < 200)
            {
                ArmorThickness = 200;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (submergeMode == false)
            {
                submergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else if (submergeMode == true)
            {
                submergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string result = this.submergeMode == true ? "ON" : "OFF";
            sb.AppendLine($" *Submerge mode: {result}");
            return sb.ToString().TrimEnd();
        }
    }
}
