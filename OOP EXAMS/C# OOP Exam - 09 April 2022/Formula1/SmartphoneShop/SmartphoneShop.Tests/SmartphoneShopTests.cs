using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
       [Test]

       public void PositiveTestConstructorShop()
        {
            Shop shop = new Shop(10);

            Assert.AreEqual(10, shop.Capacity);

            Assert.AreEqual(0, shop.Count);

            Assert.IsInstanceOf<Shop>(shop);

        }
        [Test]
        public void Ngative_Capacity()
        {


            Assert.Throws<ArgumentException>
                (

                    () => new Shop(-10), "Invalid capacity."

                );

        }
        [Test]

        public void AddPfone_Positive()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Xiaomi", 100);


            shop.Add(phone);


            Assert.AreEqual(1, shop.Count);

            Assert.That("Xiaomi" == phone.ModelName);
            Assert.That(100 == phone.MaximumBatteryCharge);


        }
        [Test]

        public void Negatide_AddPfone()
        {
            Shop shop = new Shop(2);

            Smartphone phone = new Smartphone("Xiaomi", 100);
            Smartphone phone2 = new Smartphone("Xiaomi", 100);
            Smartphone phone3 = new Smartphone("Samsung", 80);
            Smartphone phone4 = new Smartphone("Nokia", 90);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>
                (

                    () => shop.Add(phone2)

                );

            shop.Add(phone3);

            Assert.Throws<InvalidOperationException>
               (

                   () => shop.Add(phone4)

               );



        }

        [Test]

        public void RemovePhone_Positive()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Xiaomi", 100);
            Smartphone phone3 = new Smartphone("Samsung", 80);

            shop.Add(phone);
            shop.Add(phone3);

            Assert.AreEqual(2, shop.Count);

            shop.Remove(phone3.ModelName);

            Assert.AreEqual(1, shop.Count);
        }

        [Test]

        public void RemovePhone_Negative()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Xiaomi", 100);
            Smartphone phone3 = new Smartphone("Samsung", 80);
            Smartphone phone4 = new Smartphone("Nokia", 90);

            shop.Add(phone);
            shop.Add(phone3);


            Assert.Throws<InvalidOperationException>
              (

                  () => shop.Remove(phone4.ModelName)

              );

        }

        [Test]

        public void TestPhone_Positive()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Xiaomi", 100);

            shop.Add(phone);

            phone.CurrentBateryCharge = 70;

            shop.TestPhone(phone.ModelName, 50);

            Assert.AreEqual(20, phone.CurrentBateryCharge);


        }

        [Test]

        public void TestPhone_Negative()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Xiaomi", 100);

            Assert.Throws<InvalidOperationException>
              (

                  () => shop.TestPhone(phone.ModelName, 30)

              );

            shop.Add(phone);

            phone.CurrentBateryCharge = 20;

            Assert.Throws<InvalidOperationException>
             (

                 () => shop.TestPhone(phone.ModelName, 30)

             );

        }

        [Test]

        public void ChargePhone_Positive()
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Xiaomi", 100);

            shop.Add(phone);

            phone.CurrentBateryCharge = 20;

            shop.ChargePhone(phone.ModelName);

            Assert.AreEqual(100, phone.CurrentBateryCharge);

        }

        [Test]

        public void ChargePhone_Negative() 
        {
            Shop shop = new Shop(10);

            Smartphone phone = new Smartphone("Xiaomi", 100);

            Assert.Throws<InvalidOperationException>
           (

               () => shop.ChargePhone(phone.ModelName)

           );


        }
    }
}