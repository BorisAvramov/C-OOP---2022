using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {

        Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 },

        };
        private string type;
        private int grams;
        private double calories;

     


        public Topping(string type, int garms )
        {

            Type = type;
            Grams = garms;
            calories = CalculateCalories();
            
            
        }
        public double Calories
        {
            get { return calories; }
            
        }
        public int Grams
        {
            get { return grams; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{type} weight should be in the range [1..50].");

                }
                
                grams = value; 
            }
        }

        public string Type
        {
            get { return type; }
            set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }


                type = value; 
            
            
            }
        }
        public double CalculateCalories()
        {
            

            return calories =  2 * grams * modifiers[type.ToLower()]; ; 

        }


    }
}
