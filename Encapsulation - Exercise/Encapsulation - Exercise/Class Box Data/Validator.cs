using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public static  class Validator
    {
       public static void IsValidProp(string name ,double prop) 
        {
            if (prop < 0)
            {
                throw new ArgumentException($"{name} cannot be zero or negative.");
            }

        }



    }
}
