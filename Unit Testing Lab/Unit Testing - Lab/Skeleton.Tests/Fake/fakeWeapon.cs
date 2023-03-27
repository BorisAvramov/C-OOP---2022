using Skeleton.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fake
{
    public class fakeWeapon : IWeapon
    {
        public int AttackPoints => 50;

        public int DurabilityPoints { get { return 30; } set { ; } }

        public void Attack(ITarget target)
        {
            if (DurabilityPoints <= 0)
            {
                throw new InvalidOperationException("Axe is broken.");
            }

            target.TakeAttack(AttackPoints);
            DurabilityPoints -= 1;

            
        }
    }
}
