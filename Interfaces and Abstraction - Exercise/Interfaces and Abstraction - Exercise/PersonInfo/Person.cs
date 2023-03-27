using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public abstract class Person : IPerson, IIdentifiable, IBirthable
    {
        protected Person(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }

        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }
    }
}
