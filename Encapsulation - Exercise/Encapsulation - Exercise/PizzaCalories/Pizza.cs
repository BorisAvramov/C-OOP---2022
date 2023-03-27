using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private double calories;



        public Pizza(string name, Dough dough)
        {
            Name = name;
            this.dough = dough;
            toppings = new List<Topping>();
           
        }


        public IReadOnlyCollection<Topping> Toppings => toppings.AsReadOnly();
        public double Calories => dough.Calorioes + toppings.Sum(t => t.Calories);

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                
                
                name = value; 
            
            
            }
        }

        public void AddTopping(Topping toping)
        {
            if (toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }

            toppings.Add(toping);

        }


    }
}
