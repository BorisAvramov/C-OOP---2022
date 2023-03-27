using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode = false;


        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {




        }

        public bool SonarMode 
        {

            get {return sonarMode; }
           private set
            {
                sonarMode = value;

            }
        
        
        
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 300)
            {
                ArmorThickness = 300;
            }

        }

        public void ToggleSonarMode()
        {
            if (sonarMode == false)
            {
                sonarMode = true;
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else if (sonarMode == true)
            {
                sonarMode = false;
                MainWeaponCaliber -= 40;
                Speed += 5;
            }

        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            string result = this.sonarMode == true ? "ON" : "OFF";
            sb.AppendLine($" *Sonar mode: {result}");
            return sb.ToString().TrimEnd();
        }
    }
}
