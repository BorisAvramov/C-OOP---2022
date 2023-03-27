using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]

            public void PositiveTest_CtorPlanet()
            {
                Planet planet = new Planet("Earth", 2000000);

                Assert.AreEqual(0, planet.Weapons.Count);
                Assert.That(planet.Weapons, Is.Not.Null);
                Assert.That(planet, Is.Not.Null);

                Assert.AreEqual("Earth", planet.Name);
                Assert.AreEqual(2000000, planet.Budget);

                Assert.That(planet.Weapons is IReadOnlyCollection<Weapon>);
            }
            [Test]
            public void Exception_NamePlanet()
            {
                Assert.Throws<ArgumentException>
                    (
                    
                        () => new Planet(null, 2000000)
                    
                    );

                Assert.Throws<ArgumentException>
                   (

                       () => new Planet("", 2000000)

                   );

            }
            [Test]
            public void Exception_BudgetPlanet()
            {
                Assert.Throws<ArgumentException>
                    (

                        () => new Planet("Earth", -2000000)

                    );

            }
            [Test]

            public void Positive_Weapon_Ctor()
            {
                Weapon weapon = new Weapon("bomb", 1000000, 8);

                Assert.That((Weapon)weapon, Is.EqualTo(weapon));
                Assert.That(weapon, Is.Not.Null);
                Assert.AreEqual("bomb", weapon.Name);
                Assert.AreEqual(1000000, weapon.Price);
                Assert.AreEqual(8, weapon.DestructionLevel);
                Assert.That(weapon.IsNuclear == false);
            }
            [Test]
            public void Exception_PriceWeapon()
            {
                Assert.Throws<ArgumentException>
                    (

                        () => new Weapon("bomb", -1000000, 8)

                    );

            }

            [Test]

            public void Test_IncreaseDestructionLeveWeapon()
            {
                Weapon weapon = new Weapon("bomb", 1000000, 8);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.IsNuclear == false);
                weapon.IncreaseDestructionLevel();
                Assert.That(weapon.IsNuclear == true);
                Assert.AreEqual(10, weapon.DestructionLevel);

            }

            [Test]

            public void Positive_AddWeaponToPlanet()
            {
                Planet planet = new Planet("Earth", 2000000);

                Weapon weapon = new Weapon("bomb", 1000000, 8);
                Weapon weapon2 = new Weapon("bigBomb", 3000000, 11);
                Assert.AreEqual(0, planet.Weapons.Count);
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(2, planet.Weapons.Count);

            }
            [Test]

            public void Neagtive_AddWeaponToPlanet()
            {
                Planet planet = new Planet("Earth", 2000000);

                Weapon weapon = new Weapon("bomb", 1000000, 8);
                Weapon weapon2 = new Weapon("bomb", 1000000, 8);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>
                    (

                        () => planet.AddWeapon(weapon2)

                    );
                Weapon weapon3 = new Weapon("bomb", 2000000, 7);
                Assert.Throws<InvalidOperationException>
                   (

                       () => planet.AddWeapon(weapon3)

                   );


            }

            [Test]

            public void Positive_Planet_MilitaryPowerRatio()
            {
                Planet planet = new Planet("Earth", 2000000);

                Weapon weapon = new Weapon("bomb", 1000000, 8);
                Weapon weapon2 = new Weapon("bigBomb", 3000000, 11);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                Assert.AreEqual(19, planet.MilitaryPowerRatio);

            }

            [Test]

            public void Test_Planet_Profit()
            {
                Planet planet = new Planet("Earth", 2000000);
                planet.Profit(1000000);

                Assert.AreEqual(3000000, planet.Budget);
            }

            [Test]
            public void Positive_Planet_SpendFunds()
            {
                Planet planet = new Planet("Earth", 2000000);
                planet.SpendFunds(1000000);

                Assert.AreEqual(1000000, planet.Budget);
            }

            [Test]
            public void Negative_Planet_SpendFunds()
            {
                Planet planet = new Planet("Earth", 2000000);

                Assert.Throws<InvalidOperationException>
                  (

                      () => planet.SpendFunds(3000000)

                  );
                

                
            }

            [Test]
            public void RemoveWeapon_Positive()
            {
                Planet planet = new Planet("Earth", 2000000);

                Weapon weapon = new Weapon("bomb", 1000000, 8);
                Weapon weapon2 = new Weapon("bigBomb", 3000000, 11);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                Assert.AreEqual(2, planet.Weapons.Count);
                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.That(planet.Weapons.Contains(weapon2));

                planet.RemoveWeapon(weapon.Name);

                Assert.AreEqual(1, planet.Weapons.Count);
                Assert.That(planet.Weapons.Contains(weapon2));
            }
            [Test]
            public void UpgradeWeapon_Positive()
            {
                Planet planet = new Planet("Earth", 2000000);

                Weapon weapon = new Weapon("bomb", 1000000, 8);
                Weapon weapon2 = new Weapon("bigBomb", 3000000, 11);

                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);

                planet.UpgradeWeapon(weapon.Name);
                planet.UpgradeWeapon(weapon2.Name);
                planet.UpgradeWeapon(weapon2.Name);

                Assert.AreEqual(9, weapon.DestructionLevel);
                Assert.AreEqual(13, weapon2.DestructionLevel);


            }
            [Test]
            public void UpgradeWeapon_Negative()
            {
                Planet planet = new Planet("Earth", 2000000);

                Weapon weapon = new Weapon("bomb", 1000000, 8);
                Weapon weapon2 = new Weapon("bigBomb", 3000000, 11);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>
                 (

                     () => planet.UpgradeWeapon(weapon2.Name)

                 );



            }
            [Test]

            public void DestructOpponent_Pos()
            {
                Planet earth = new Planet("Earth", 2000000);

                Planet mars = new Planet("Mars", 5000000);

                Weapon weapon = new Weapon("bomb", 1000000, 8);
                Weapon weapon2 = new Weapon("bigBomb", 3000000, 11);

                earth.AddWeapon(weapon);
                earth.AddWeapon(weapon2);


                Weapon weapon3 = new Weapon("bigbigBomb", 3000000, 20);
                Weapon weapon4 = new Weapon("bigbigbigBomb", 3000000, 30);

                mars.AddWeapon(weapon3);
                mars.AddWeapon(weapon4);

                string result = mars.DestructOpponent(earth);

                Assert.That(mars.MilitaryPowerRatio > earth.MilitaryPowerRatio);

                Assert.AreEqual("Earth is destructed!", result);


            }
            [Test]

            public void DestructOpponent_Negative()
            {
                Planet earth = new Planet("Earth", 2000000);

                Planet mars = new Planet("Mars", 5000000);

                Weapon weapon = new Weapon("bomb", 1000000, 20);
                Weapon weapon2 = new Weapon("bigBomb", 3000000, 30);

                earth.AddWeapon(weapon);
                earth.AddWeapon(weapon2);


                Weapon weapon3 = new Weapon("bigbigBomb", 3000000, 5);
                Weapon weapon4 = new Weapon("bigbigbigBomb", 3000000, 7);

                mars.AddWeapon(weapon3);
                mars.AddWeapon(weapon4);

                //string result = mars.DestructOpponent(earth);


                Assert.Throws<InvalidOperationException>
               (

                   () => mars.DestructOpponent(earth)

               );

                Planet saturn = new Planet("Saturn", 5000000);

                Weapon weapon5 = new Weapon("littleBomb", 500000, 50);
                saturn.AddWeapon(weapon5);

                Assert.Throws<InvalidOperationException>
              (

                  () => earth.DestructOpponent(saturn)

              );


            }
        }
    }
}
