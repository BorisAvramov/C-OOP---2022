using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;

      
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            sonarMode = false;

            this.initialArmorThickness = 300;
        }


        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
                SonarMode = true;
            }
            else if (SonarMode == true)
            {
                MainWeaponCaliber -= 40;
                Speed += 5;

                SonarMode = false;
            }
           

        }


        //public override void RepairVessel()
        //{
        //    if (this.ArmorThickness < 300)
        //    {
        //        this.ArmorThickness = 300;
        //    }
        //}

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            string result = SonarMode == true ? "ON" : "OFF";
            sb.AppendLine($"*Sonar mode: {result}");

            return sb.ToString().TrimEnd();
        }
    }
}
