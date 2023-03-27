namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class CarManagerTests
    {

        [Test]

        public void Test_constructorData()
        {
            Car car = new Car("Opel", "Astra", 7.5, 55);

            Assert.AreEqual("Opel", car.Make);
            Assert.AreEqual("Astra", car.Model);
            Assert.AreEqual(7.5, car.FuelConsumption);
            Assert.AreEqual(55, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);

        }

        [Test]
        public void Test_Make_ThrwoExc_NullOrEmpty()
        {
           
                Assert.Throws<ArgumentException>(
                    () =>
                    {
                        Car car = new Car("", "Astra", 7.5, 55);
                       
                    }
                
                
                );
            Assert.Throws<ArgumentException>(
                    () =>
                    {
                        
                        Car car2 = new Car(null, "Astra", 7.5, 55);
                    }


                );


        }

        [Test]
        public void Test_Model_ThrwoExc_NullOrEmpty()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car("Opel", "", 7.5, 55);

                }


            );
            Assert.Throws<ArgumentException>(
                    () =>
                    {

                        Car car2 = new Car("Opel", null, 7.5, 55);
                    }


                );


        }

        [Test]
        public void Test_FuelConsumption_ThrwoExc_LessOrEqualTo0()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car("Opel", "Astra", 0, 55);

                }


            );
            Assert.Throws<ArgumentException>(
                    () =>
                    {

                        Car car2 = new Car("Opel", "Astra", -15, 55);
                    }


                );


        }
        [Test]

        public void Test_FuelAmountLessThan0()
        {
            Car car = new Car("Opel", "Astra", 7.5, 55);
            if (car.FuelAmount < 0)
            {
                throw new ArgumentException();
            }

        }
         [Test]
        public void Test_FuelCapacity_ThrwoExc_LessOrEqualTo0()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Car car = new Car("Opel", "Astra", 7.5, 0);

                }


            );
            Assert.Throws<ArgumentException>(
                    () =>
                    {

                        Car car2 = new Car("Opel", "Astra", 7.5, -55);
                    }


                );


        }

        [TestCaseSource("CaseSourceCarRefuelAmount")]

        public void Test_Negativ_ThrowExc_When_refueLAmountIsLessOrEqualTo0(
            Car car,
            double fuelToRefuel
            )
        {
            Assert.Throws<ArgumentException>(
                ()=> car.Refuel(fuelToRefuel)
                
                );

        }

        public static IEnumerable<TestCaseData> CaseSourceCarRefuelAmount()
        {
            yield return new TestCaseData(
                new Car ("Opel", "Astra", 7.5, 55),
                0 );

            yield return new TestCaseData(
               new Car("Opel", "Astra", 7.5, 55),
               -10);


        }

        [Test]

        public void Test_Positive_AmountMustIncrease_WhenRefuel()
        {
            Car car = new Car("Opel", "Astra", 7.5, 55);

            car.Refuel(10);
            car.Refuel(20);

            Assert.AreEqual(30, car.FuelAmount);


        }
        [Test]

        public void Test_Positive_IfAmountIsGreaterThanCapacityMustReturnCapacity()
        {
            Car car = new Car("Opel", "Astra", 7.5, 55);

            car.Refuel(60);

            Assert.AreEqual(55, car.FuelAmount);


        }
        [Test]

        public void Test_FuelNeededToDriveDistance()
        {
            Car car = new Car("Opel", "Astra", 7.5, 55);

            
            double fuelNeeded = (450.0 / 100) * car.FuelConsumption;

            Assert.AreEqual(33.75, fuelNeeded);

        }

        [Test]

        public void Test_Negative_FuelNeededIsGreaterThanAmount_ThrowExc()
        {
            Car car = new Car("Opel", "Astra", 7.5, 55);

            car.Refuel(20);

            Assert.Throws<InvalidOperationException>(
                () => car.Drive(450)

                );

        }
        [Test]

        public void Test_Positive_FuelAmountMustDecreaseWithFuelNeeded()
        {
            Car car = new Car("Opel", "Astra", 7.5, 55);
            car.Refuel(50);

            car.Drive(450);

            Assert.AreEqual(16.25, car.FuelAmount);

            

        }

    }
}