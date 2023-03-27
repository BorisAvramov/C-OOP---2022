using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) 
            : base(name, favouriteFood )
        {
        }

        public override string ExplainSelf()
        {
            return "DJAAF";
        }
        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}
