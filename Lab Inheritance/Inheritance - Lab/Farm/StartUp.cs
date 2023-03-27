using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();

            myDog.Eat();
            myDog.Bark();

            Puppy puppy = new Puppy();

            puppy.Eat();
            puppy.Bark();
            puppy.Weep();    

            Cat cat = new Cat();

            cat.Eat();
            cat.Meow();

        }
    }
}
