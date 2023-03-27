using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode ;


        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 200)
        {

            submergeMode = false ;
            this.initialArmorThickness = 200;
        }

        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
                SubmergeMode = true;
            }
            else if (SubmergeMode == true)
            {
                MainWeaponCaliber -= 40;
                Speed += 4;

                SubmergeMode = false;
            }


        }


        //public override void RepairVessel()
        //{
        //    if (this.ArmorThickness < 200)
        //    {
        //        this.ArmorThickness = 200;
        //    }
        //}

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            string result = SubmergeMode == true ? "ON" : "OFF";
            sb.AppendLine($"*Submerge mode: {result}");

            return sb.ToString().TrimEnd();
        }
    }
}
