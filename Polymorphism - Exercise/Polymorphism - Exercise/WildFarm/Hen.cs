using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food food)
        {
            
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.35;
            
            
        }

        public override string ProducedSound()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
