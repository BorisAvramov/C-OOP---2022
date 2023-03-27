using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private string name;

        private string favouriteFood;

        protected Animal(string name, string favouriteFood )
        {
            FavouriteFood = favouriteFood;
            Name = name;
        }

        public string FavouriteFood
        {
            get { return favouriteFood; }
            set { favouriteFood = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public abstract string ExplainSelf();
        public override string ToString()
        {
            return $"I am {Name} and my fovourite food is {FavouriteFood}";
        }

    }
}
