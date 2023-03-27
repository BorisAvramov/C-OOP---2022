using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    internal class Pet : IBirthable
    {
        public Pet(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public string Name { get;  }
        public string BirthDate { get; }
    }
}
