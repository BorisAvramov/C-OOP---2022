using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IRidingGroup
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name {get; }

        public abstract int Power { get; }

        public abstract string CastAbility();
        
    }
}
