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
        private ICaptain captain;
        private List<string> targets;
        protected int initialArmorThickness = 0;


        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
            captain = new Captain("default");
            

        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(string.Format(ExceptionMessages.InvalidVesselName));
                }
                name = value;
            }
        }



        public ICaptain Captain
        {
            get { return captain; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCaptainToVessel));
                }

                captain = value; 
            
            }
        }


        public double ArmorThickness { get;  set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target is null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.InvalidTarget));
            }

            target.ArmorThickness = (target.ArmorThickness - this.MainWeaponCaliber) < 0 ? 0 :(target.ArmorThickness - this.MainWeaponCaliber);
            this.targets.Add(target.Name);
        }

        public  void RepairVessel()
        {
            if (this.ArmorThickness < this.initialArmorThickness)
                this.ArmorThickness = this.initialArmorThickness;
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {this.GetType().Name}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");
            string result = targets.Count == 0 ? "None" : string.Join(", ", targets);
            sb.AppendLine($"*Targets: {result}");

            return sb.ToString().TrimEnd();
        }

    }
}
