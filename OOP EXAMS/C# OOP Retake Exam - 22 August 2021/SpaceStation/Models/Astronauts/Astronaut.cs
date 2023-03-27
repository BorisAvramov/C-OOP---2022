using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            bag = new Backpack();
        }


        public double Oxygen 
        {
            get { return oxygen; }
          protected  set 
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidOxygen);

                }
                oxygen = value;
            
            }
        }


        public string Name
        {
            get { return name; }
           private set
           
            
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }
                name = value;
            
            
            }
        }




        public bool CanBreath { get; private set; }

        public IBag Bag => bag;
       

        public virtual void Breath()
        {
            if (Oxygen - 10 < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 10;
            }

        }
    }
}
