using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using Skeleton.Tests.Fake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    public class HeroTests
    {
        [Test]

        public void Test_IfHeroGainXP_WhenTargetDies()
        {

            Mock<IWeapon> weopen = new Mock<IWeapon>();
            weopen.Setup(w => w.AttackPoints).Returns(50);


            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(t => t.IsDead()).Returns(true);
            target.Setup(t => t.Experience).Returns(60);



            //IWeapon weapon = new fakeWeapon();
            //ITarget target = new fakeTarget();

           
            
            

            Hero hero = new Hero(weopen.Object, target.Object);


            hero.HerosWeaponeAttack(weopen.Object, target.Object);

            Assert.AreEqual(60, hero.experience);


            

        }

    }
}
