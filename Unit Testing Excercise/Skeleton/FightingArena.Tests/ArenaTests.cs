namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]

        public void Test_Constructor()
        {
            Arena arena = new Arena();


            Assert.IsNotNull(arena.Warriors);

            Assert.AreEqual(arena.Count, arena.Warriors.Count);
            Assert.AreEqual(0, arena.Count);
        }

        [Test]

        public void TestCount()
        {
            Arena arena = new Arena();
            Assert.AreEqual(0, arena.Warriors.Count);


        }

        [Test]

        public void Test_Positive_EnrollWarriorToTheArena()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Aragaron", 35, 50);
              
            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);

            Assert.True(arena.Warriors.Any(w=>w.Name == warrior.Name));


        }


        [Test]

        public void Test_Negative_ThrowExc_WhenWarriorNameAlreadyExistInWarriorsList()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Aragaron", 35, 50);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior)

                );



        }
        

        [Test]

        public  void Test_Positive_FightAttack()

        {
            Arena arena = new Arena();
            Warrior attackerer = new Warrior("Aragaron", 35, 50);
            Warrior defender = new Warrior("Saroman", 20, 40);
            arena.Enroll(attackerer);
            arena.Enroll(defender);

            arena.Fight("Aragaron", "Saroman");

            Assert.AreEqual(30, attackerer.HP);
            Assert.AreEqual(5, defender.HP);


        }

        [Test]

        public void Test_Negative_MissingName_AttacherOrDefender()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Aragaron", 35, 50);
            arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(
               () => arena.Fight("Aragaron", "Saroman")
                
                );
            Arena arena2 = new Arena();
            Warrior defender = new Warrior("Saroman", 35, 50);
            arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(
               () => arena2.Fight("Aragaron", "Saroman")

                );

        }



    }
}
