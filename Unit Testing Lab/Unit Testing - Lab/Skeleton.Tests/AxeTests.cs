using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void InitialAxeAndDummy()
        {
             axe = new Axe(5, 2);
             dummy = new Dummy(10, 20);
        }

        [Test]
        public void doesAxeLoseDurabilityWnenattack()
        {
            
            

            axe.Attack(dummy);

            Assert.AreEqual(1, axe.DurabilityPoints);
            


        }
        [Test]

        public void ChechAxeIsBroken()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);





            Assert.Throws<InvalidOperationException>(() =>

            axe.Attack(new Dummy(20, 20))
            , "Brokean Weapon");


        }
    }
}