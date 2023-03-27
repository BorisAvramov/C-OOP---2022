using Skeleton.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    public class Hero : IHero
    {
        public ITarget Target { get; set; }
        public IWeapon Weapon { get; set; }
        public int experience { get; set; }

        public Hero( IWeapon weapon, ITarget target)
        {
            Weapon = weapon;
            Target = target;
            experience = 0;
        }

        public void HerosWeaponeAttack(IWeapon weapon, ITarget target)
        {
            weapon.Attack(target);
            //target.Health -= weapon.AttackPoints;

            if (target.IsDead())
            {
                experience = target.Experience;
            }


        }



    }
}
