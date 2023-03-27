namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    public class WarriorTests
    {
        
        [Test]

        public void Test_constructor()
        {
            Warrior warrior = new Warrior("Aragaron",50, 100 );

            Assert.AreEqual("Aragaron", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void Test_Negative_NameThrowsExc_NullEmptyWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 50, 100));
            Assert.Throws<ArgumentException>(() => new Warrior(null, 50, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("  ", 50, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Aragaron", 0, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Aragaron", -5, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("Aragaron", 50, -5));
        }

      [TestCaseSource("SourceDataWarriorAndEnemyWarrior")]

      public void Test_Negative_ThrowExc_HPLessOrEqualTo30_HpLessThanEnemyDamage(
          Warrior warrior,
          Warrior enemyWarrior
          )
        {

            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(enemyWarrior)

                );
        }

        public static IEnumerable<TestCaseData> SourceDataWarriorAndEnemyWarrior()
        {
            yield return new TestCaseData(
                new Warrior("Aragaron", 50, 20),
                new Warrior("Saroman", 50, 50)
                );
            yield return new TestCaseData(
                new Warrior("Aragaron", 50, 30),
                new Warrior("Saroman", 50, 50)
                );
            yield return new TestCaseData(
                new Warrior("Aragaron", 50, 50),
                new Warrior("Saroman", 50, 20)
                );
            yield return new TestCaseData(
               new Warrior("Aragaron", 50, 50),
               new Warrior("Saroman", 50, 30)
               );
            yield return new TestCaseData(
               new Warrior("Aragaron", 50, 40),
               new Warrior("Saroman", 50, 30)
               );

        }
        [Test]

        public void Test_Positive_MustDecreaseHPWithDamageOfTheEnemy()
        {
            Warrior warrior = new Warrior("Aragaron", 50, 50);
            Warrior warriorEnemy = new Warrior("Saroman", 20, 70);

            warrior.Attack(warriorEnemy);

            Assert.AreEqual(30, warrior.HP);

        }
        [Test]

        public void Test_Positive_EnemyHPIsequal0_WhenWarriorDamageIsGreaterThanEnemyHP()
        {
            Warrior warrior = new Warrior("Aragaron", 50, 50);
            Warrior warriorEnemy = new Warrior("Saroman", 20, 35);

            warrior.Attack(warriorEnemy);

            Assert.AreEqual(0, warriorEnemy.HP);

        }

        [Test]

        public void Test_Positive_EnemyHPDecreaseWithDamageOfTheWarriorWhenDamageIsLessOrEqualToEnemyHP()
        {
            Warrior warrior = new Warrior("Aragaron", 35, 50);
            Warrior warriorEnemy = new Warrior("Saroman", 20, 40);

            warrior.Attack(warriorEnemy);

            Assert.AreEqual(5, warriorEnemy.HP);
            Assert.AreEqual(30, warrior.HP);

            warrior = new Warrior("Aragaron", 35, 50);
            warriorEnemy = new Warrior("Saroman", 20, 35);

            warrior.Attack(warriorEnemy);

            Assert.AreEqual(0, warriorEnemy.HP);
            Assert.AreEqual(30, warrior.HP);

        }
        //[Test]
        //public void Test_Negative_NameThrowsExc_NullEmptyWhiteSpace()
        //{
        //    Assert.Throws<ArgumentException>(
        //         () =>
        //         {

        //             Warrior warrior = new Warrior("", 50, 100);
        //         }


        //     );
        //    Assert.Throws<ArgumentException>(
        //         () =>
        //         {

        //             Warrior warrior = new Warrior(null, 50, 100);
        //         }


        //     );
        //    Assert.Throws<ArgumentException>(
        //       () =>
        //       {

        //           Warrior warrior = new Warrior("  ", 50, 100);
        //       }


        //   );

        //}
        //[Test]
        //public void Test_Negative_DamageThrowException_WhenIsLessOrEqualTo0()
        //{
        //    Assert.Throws<ArgumentException>(
        //         () =>
        //         {

        //             Warrior warrior = new Warrior("Aragaron", 0, 100);
        //         }


        //     );
        //    Assert.Throws<ArgumentException>(
        //         () =>
        //         {

        //             Warrior warrior = new Warrior("Aragaron", -5, 100);
        //         }


        //     );


        //}
        //[Test]
        //public void Test_Negative_HPThrowException_WhenIsNegative()
        //{
        //    Assert.Throws<ArgumentException>(
        //         () =>
        //         {

        //             Warrior warrior = new Warrior("Aragaron", 50, -5);
        //         }


        //     );

        //}


    }
}