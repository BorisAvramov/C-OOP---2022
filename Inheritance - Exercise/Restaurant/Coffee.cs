using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double Caffeine)
            : base(name, 3.50m, 50)
        {
            this.Caffeine = Caffeine;
        }

        public double Caffeine { get; set; }
    }
}
