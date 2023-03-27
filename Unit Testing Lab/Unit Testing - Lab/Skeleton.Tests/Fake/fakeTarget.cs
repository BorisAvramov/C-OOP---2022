using Skeleton.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests.Fake
{
    public class fakeTarget : ITarget
    {
        public fakeTarget()
        {
            Health = 20;
        }

        public int Health { get; set; }

        public int Experience => 60;

        public int GiveExperience()
        {
           return 60;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
            if (this.IsDead())
            {
                throw new InvalidOperationException("Dummy is dead.");
            }

            Health = 0;
        }
    }
}
