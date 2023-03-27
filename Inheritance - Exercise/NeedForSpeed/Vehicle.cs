using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {

        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }


        public virtual double FuelConsumption => DefaultFuelConsumption;
        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public virtual void Drive(double kilometers) 
        {
            if (Fuel - (kilometers * FuelConsumption) >= 0)
            {
                Fuel -= kilometers * FuelConsumption;
            }

        }

    }
}
