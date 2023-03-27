using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface IHero
    {
        public ITarget Target { get; set; }
        public IWeapon Weapon { get; set; }

        public int experience { get; set; }





    }
}
