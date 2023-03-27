using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface IWeapon
    {
       


        public int AttackPoints { get; }


        public int DurabilityPoints { get;  set; }


        public void Attack(ITarget target);
   

    }
}
