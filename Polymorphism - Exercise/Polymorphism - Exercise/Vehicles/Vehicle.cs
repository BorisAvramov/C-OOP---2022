using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

       


        protected Vehicle(double fuelQuantity, double fuelConsumption,  double tankCapacity )
        {
            this.fuelConsumption = fuelConsumption;
            this.fuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.tankCapacity = tankCapacity;
        }


        public double TankCapacity
        {
            get { return tankCapacity; }
           protected set { tankCapacity = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            protected set { fuelConsumption = value; }
        }


        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                
                    fuelQuantity = value;
                


            }



           
        }
        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);


    }
}
