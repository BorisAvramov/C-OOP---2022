using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {

        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }

                weapon = value; 
            }
        }


        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }


        public int Health
        {
            get { return health; }
            private set

            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }




        

        public bool IsAlive => this.health > 0 ? true : false;






        public void AddWeapon(IWeapon weapon)
        {
            this.weapon = weapon;

             
        }

        public void TakeDamage(int points)
        {
            int diff = points > Armour ? points - Armour : 0;
            
            if (this.Armour - points <= 0)
            {
                Armour = 0;


            }
            else
            {
                this.Armour -= points;
            }

            if (this.Health - diff <= 0)
            {
                Health = 0;
            }
            else
            {
                this.Health -= diff;
            }

            
            

            
        }
    }
}
