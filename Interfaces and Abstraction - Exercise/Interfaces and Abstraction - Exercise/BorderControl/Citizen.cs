using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable, IBirthable, IBuyer
    {
        private int food = 0;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;

        }

        public Citizen(string name, int age, string id, string birthdate) : this(name, age, id)
        {
            BirthDate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string BirthDate { get; }
        public int Food => food;

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
