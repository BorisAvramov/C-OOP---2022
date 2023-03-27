using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool defaultSubmergeMode = false;
        private bool defaultSonarMode = false;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.initialArmorThickness = 200;
        }

        public bool SubmergeMode { get => defaultSubmergeMode; private set => defaultSubmergeMode = value; }

        public bool SonarMode { get => defaultSonarMode; private set => defaultSonarMode = value; }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
            else
            {
                this.SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var submergeModeText = this.SubmergeMode == true ? "ON" : "OFF";
            sb.AppendLine($" *Submerge mode: {submergeModeText}");
            return base.ToString() + Environment.NewLine + sb.ToString().Trim();
            
        }
    }
}
