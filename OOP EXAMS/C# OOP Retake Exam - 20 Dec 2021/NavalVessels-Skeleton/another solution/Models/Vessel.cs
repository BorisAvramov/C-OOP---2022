using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain = new Captain("default");
        private ICollection<string> targets = new List<string>();
        protected int initialArmorThickness = 0;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                this.name = value;
            }
        }

        public ICaptain Captain 
        { 
            get => captain;
            set
            {
                if(value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get => targets; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if(target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            if(this.ArmorThickness < this.initialArmorThickness)
            this.ArmorThickness = this.initialArmorThickness;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {this.Speed} knots");
            if(this.Targets.Count == 0)
            {
                sb.AppendLine("*Targets: None");
            }
            else
            {
                sb.AppendLine($"*Targets: {String.Join(", ", this.Targets)}");
            }
            return sb.ToString().Trim();
        }
    }
}
