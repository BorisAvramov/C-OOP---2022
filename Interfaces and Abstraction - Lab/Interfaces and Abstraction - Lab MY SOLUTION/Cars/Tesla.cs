using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int battery) 
            : base(model, color)
        {
            Battery = battery;
        }

        public int Battery { get;}

        public override string ToString()
        {
            return $"{base.ToString()} with {this.Battery} Batteries";
        }

    }
}
