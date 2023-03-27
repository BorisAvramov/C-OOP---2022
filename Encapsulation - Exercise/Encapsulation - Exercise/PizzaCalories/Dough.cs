using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int grams;
        private double calories;

        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            { "white", 1.5},
            { "wholegrain", 1.0},
            { "crispy", 0.9},
            { "chewy", 1.1 },
            { "homemade", 1.0 },

        };

      
        public Dough(string flourType, string bakingTechnique, int grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
            calories = CalculatCalories();
        }

        public double Calorioes
        {
            get
            {
                return calories;

            }
           

        }
        public int Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                grams = value;

            }

        }
        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value; 
            }
        }


        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                
                flourType = value; 
            }
        }

        private double CalculatCalories() 
        {
           return calories = 2 * grams * modifiers[flourType.ToLower()] * modifiers[bakingTechnique.ToLower()];
            
        }



    }
}
