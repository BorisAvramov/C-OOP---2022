using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.

        private string name;
        private double health;
        private double armor;
        private double abilityPoints;
        private IBag bag;
        

        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }


        public double BaseArmor  { get; private set; }
        public double BaseHealth  { get; private set; }

        public IBag Bag
        {
            get { return bag; }
           private set { bag = value; }
        }


        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        public double Armor
        {
            get { return armor; }
           private set 
            { 
                
                armor = value;
                if (armor <0)
                {
                    armor = 0;
                }
            
            }
        }



        public double Health
        {
            get { return health; }
            set 
            { 
                health = value;
                if (health < 0)
                {
                    health = 0;
                }
                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            
            }
        }


        public string Name
        {
            get { return name; }
           private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value; 
            }
        }



        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            double leftpoints = (hitPoints - armor) > 0 ?
              hitPoints - armor :
              0;

            if (this.IsAlive)
            {
                this.armor -= hitPoints;

                if (armor < 0)
                {
                    armor = 0;
                }
            }
          



            this.health -= leftpoints;
            if (health < 0)
            {
                health = 0;
            }

            this.IsAlive = health <= 0 ?
            false :
            true;



        }
        public void UseItem(Item item)
        {
            item.AffectCharacter(this);

        }
    }
}