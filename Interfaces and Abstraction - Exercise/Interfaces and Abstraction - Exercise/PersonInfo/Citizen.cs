using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : Person
    {
        public Citizen(string name, int age, string id, string birthdate) : base(name, age, id, birthdate)
        {
        }
    }
}
