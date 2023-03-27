using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country,  int age)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; set; }
        
        public int Age { get; set; }
        public string Country { get; set; }

        string IPerson.GetName()
        {
            return Name;
        }

         string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {Name}";
        }
    }
}
