using System;

namespace RepairShop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage("Auto", 3);
            Car car = new Car("opel", 1);
            Car car2 = new Car("audi", 3);
            Car car3 = new Car("bmw", 2);

            garage.AddCar(car);
            garage.AddCar(car2);
            garage.AddCar(car3);

            Console.WriteLine(garage.Report());


        }
    }
}
