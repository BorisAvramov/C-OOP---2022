using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
             int result =  this.Durability - 1;

            if (result <= 0)
            {
                Durability = 0;
                return 0;
            }
            else
            {
                Durability -= 1;
                return 25;
            }
        }
    }
}
