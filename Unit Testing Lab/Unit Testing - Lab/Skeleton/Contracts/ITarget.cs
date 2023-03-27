using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface ITarget
    {
        public int Health { get; set; }

       
        public int Experience { get; }


        public void TakeAttack(int attackPoints);


        public int GiveExperience();


        public bool IsDead();
        


    }
}
