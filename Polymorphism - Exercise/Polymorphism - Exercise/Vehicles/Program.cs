using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] carElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int intValue = int.Parse(Console.ReadLine());

            string carName = carElements[0];
            double carFuelQuantity = double.Parse(carElements[1]);
            double carLitersConsummtion = double.Parse(carElements[2]);
            double carTankCap = double.Parse(carElements[3]);

            string truckName = truckElements[0];
            double truckFuelQuantity = double.Parse(truckElements[1]);
            double truckLitersConsummtion = double.Parse(truckElements[2]);
            double truckTankCap = double.Parse(truckElements[3]);

            string busName = busElements[0];
            double busFuelQuantity = double.Parse(busElements[1]);
            double busLitersConsummtion = double.Parse(busElements[2]);
            double busTankCap = double.Parse(busElements[3]);

            Vehicle car = new Car(carFuelQuantity, carLitersConsummtion, carTankCap);
            Vehicle truck = new Truck( truckFuelQuantity, truckLitersConsummtion, truckTankCap);
            Bus bus = new Bus( busFuelQuantity, busLitersConsummtion, busTankCap);

            for (int i = 0; i < intValue; i++)
            {

                string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (stringElements[0] == "Drive")
                {
                    if (stringElements[1] == "Car")
                    {
                        car.Drive(double.Parse(stringElements[2]));
                    }
                    else if (stringElements[1] == "Truck")
                    {
                        truck.Drive(double.Parse(stringElements[2]));
                    }
                    else if (stringElements[1] == "Bus")
                    {
                        bus.Drive(double.Parse(stringElements[2]));
                    }

                }
                else if (stringElements[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(stringElements[2]));
                }
                else if (stringElements[0] == "Refuel")
                {
                    if (double.Parse(stringElements[2]) <= 0)
                    {
                        Console.WriteLine($"Fuel must be a positive number");
                        continue;
                    }

                    if (stringElements[1] == "Car")
                    {
                        car.Refuel(double.Parse(stringElements[2]));
                    }
                    else if (stringElements[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(stringElements[2]));
                    }
                    else
                    {
                        bus.Refuel(double.Parse(stringElements[2]));
                    }
                }   


            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");


        }
    }
}
