using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {

                string stringValue = System.Console.ReadLine();
                if (stringValue == "Beast!")
                {
                    break;
                }
                string type = stringValue;

                string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries); 

                string name = stringElements[0];
                int age = int.Parse(stringElements[1]);
                string geneder = stringElements[2];

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Animal animal = null;
                
                
                    if (type == "Cat")
                    {

                        animal = new Cat(name, age, geneder);

                    }
                    else if (type == "Dog")
                    {
                        animal = new Dog(name, age, geneder);
                    }
                    else if (type == "Frog")
                    {
                        animal = new Frog(name, age, geneder);

                    }
                    else if (type == "Kitten")
                    {
                        animal = new Kitten(name, age);

                    }
                    else if (type == "Tomcat")
                    {
                        animal = new Tomcat(name, age);

                    }

                    Console.WriteLine(type);
                    Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                    Console.WriteLine(animal.ProduceSound());
                
               


            }



        }
    }
}
