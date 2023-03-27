using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    [TestFixture]
    public class Tests
    {
        public class RepairsShopTests
        {
           [Test]

           public void Positive_Test_Constructor()
            {
                Garage garage = new Garage("Auto", 2);
                
                Assert.IsInstanceOf<Garage>(garage);
                Assert.That(garage, Is.Not.Null);
                Assert.AreEqual(0, garage.CarsInGarage);

                Assert.AreEqual("Auto", garage.Name );
                Assert.AreEqual(2, garage.MechanicsAvailable );

                //Car car = new Car("opel", 2);

                //garage.AddCar(car);


            }

            [Test]

            public void Negative_Name_IsNullOrEmpty()
            {
                

                Assert.Throws<ArgumentNullException>
                    (
                        () => new Garage(null, 2)

                    );
                Assert.Throws<ArgumentNullException>
                     (
                         () => new Garage(string.Empty, 2)

                     );

            }

            [Test]

            public void Negative_MechanicAvailable_Less_Equal_0()
            {
                Assert.Throws<ArgumentException>
                    (
                        () => new Garage("Auto", 0)

                    );
                Assert.Throws<ArgumentException>
                     (
                         () => new Garage("Auto", -2)

                     );

            }

            [Test]

            public void Positive_AddCar_ToGarage()
            {
                Garage garage = new Garage("Auto", 2);
                Car car = new Car("opel", 2);

                garage.AddCar(car);

                Assert.AreEqual(1, garage.CarsInGarage);

                
            }

            [Test]

            public void Negative_AddCar_ToGarage_When_CountCarsInGarageAreEqualToMechanicAvailable()
            {
                Garage garage = new Garage("Auto", 1);
                Car car = new Car("opel", 1);
                Car car2 = new Car("audi", 3);

                garage.AddCar(car);

                Assert.Throws<InvalidOperationException>
                     (
                         () => garage.AddCar(car2)

                     );


            }
            [Test]

            public void Positive_CarToFix_MustReturnFixedCarAndSetIssuesTo0()
            {
                Garage garage = new Garage("Auto", 2);
                Car car = new Car("opel", 2);

                garage.AddCar(car);
                Assert.AreEqual(2, car.NumberOfIssues);
               var result =  garage.FixCar(car.CarModel);

                Assert.AreEqual(0, car.NumberOfIssues);

                Assert.AreSame(car, result);
                Assert.That(result.NumberOfIssues == 0);
                Assert.That(result.CarModel == "opel");


            }
            [Test]

            public void Negative_CarToFix_CarDoesntExistInGarage()
            {
                Garage garage = new Garage("Auto", 2);
                Car car = new Car("opel", 2);

                Assert.Throws<InvalidOperationException>
                   (
                       () => garage.FixCar(car.CarModel)

                   );


            }

            [Test]
            public void Positive_RemoveFixedCarsFromGarage()
            {
                Garage garage = new Garage("Auto", 3);
                Car car = new Car("opel", 1);
                Car car2 = new Car("audi", 3);
                Car car3 = new Car("bmw", 2);

                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);

                garage.FixCar(car.CarModel);
                garage.FixCar(car2.CarModel);

                Assert.AreEqual(3, garage.CarsInGarage);
                int result = garage.RemoveFixedCar();

                Assert.AreEqual(1, garage.CarsInGarage);

                Assert.AreEqual(2, result);

            }
            [Test]
            public void Negative_RemoveFixedCars_NoFixedCarInGarage()
            {
                Garage garage = new Garage("Auto", 3);
                Car car = new Car("opel", 1);
                Car car2 = new Car("audi", 3);
                Car car3 = new Car("bmw", 2);

                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);


                Assert.Throws<InvalidOperationException>
                  (
                      () => garage.RemoveFixedCar()

                  );



            }
            [Test]
            public void Test_Report_ShouldReturnCarsNotFixed()
            {
                Garage garage = new Garage("Auto", 3);
                Car car = new Car("opel", 1);
                Car car2 = new Car("audi", 3);
                Car car3 = new Car("bmw", 2);

                garage.AddCar(car);
                garage.AddCar(car2);
                garage.AddCar(car3);

                string result = garage.Report();

                Assert.AreEqual("There are 3 which are not fixed: opel, audi, bmw.", result);
            }

        }
    }
}