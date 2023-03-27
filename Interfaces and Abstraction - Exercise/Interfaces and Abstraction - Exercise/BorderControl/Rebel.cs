using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Rebel : IBuyer
    {
        private int food = 0;

        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            
        }

        public string Name { get;   }
        public int Age { get;  }
        public string Group { get;  }

        public int Food => this.food;

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
