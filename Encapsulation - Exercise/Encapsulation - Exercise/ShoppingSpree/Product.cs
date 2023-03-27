using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;


        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;    
        }


        public decimal Cost
        {
            get { return cost; }
           private set 
            { 
                Validator.ValidMoney(value);
                
                cost = value; 
            
            
            }
        }


        public string Name
        {
            get { return name; }
          private  set 
            {
                Validator.ValidName(value);

                name = value; 
            
            
            }
        }
        public override string ToString()
        {
            return $"{Name}";
        }



    }
}
