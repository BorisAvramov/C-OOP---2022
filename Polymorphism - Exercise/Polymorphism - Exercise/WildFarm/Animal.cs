using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        private string name;

        private double weight;
        

        public Animal(string name, double weight)
        {
            Weight = weight;
            Name = name;
        }


        public int FoodEaten { get; protected set; }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }



        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public abstract string ProducedSound();

        public abstract void Feed(Food food);

    }
}
