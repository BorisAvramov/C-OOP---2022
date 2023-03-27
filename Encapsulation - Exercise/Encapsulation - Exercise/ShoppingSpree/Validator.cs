using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void ValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be empty");
            }
        
        }

        public static void ValidMoney(decimal money) 
        {

            if (money < 0)
            {
                throw new Exception("Money cannot be negative");
            }
        
        
        }

    }
}
