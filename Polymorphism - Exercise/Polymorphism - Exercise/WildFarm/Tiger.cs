﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food food)
        {
            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 1.00;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProducedSound()
        {
            return "ROAR!!!";
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
