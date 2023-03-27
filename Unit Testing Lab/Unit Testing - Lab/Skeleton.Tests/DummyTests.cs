using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void InitialDummy()
        {
            dummy = new Dummy(10, 20);
        }

        [Test]
        public void Test_DummyAttackedLoseshealth()
        {

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health, "Dummy's health does not decrease!");
        }

        [Test]
        public void Test_DeadDummyMustThrowExcWhenattacked()
        {
            dummy.TakeAttack(10);
            Assert.Throws<InvalidOperationException>(
                ()=>
                {
                    dummy.TakeAttack(5);
                }, "Dummy is dead!"
               
                );

        }
        [Test]
        public void Test_DummyAliveCantGiveXp_Negative()
        {
           

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    dummy.GiveExperience();
                }

                );
        }
        [Test]
        public void Test_DummyDeadCanGiveXp_Positive()
        {
            dummy.TakeAttack(10);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(20));

        }

    }
}