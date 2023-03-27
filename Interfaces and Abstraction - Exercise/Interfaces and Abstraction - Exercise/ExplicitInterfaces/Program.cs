using System;

namespace ExplicitInterfaces
{
    public class Program
    {
       public static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }


                string[] stringElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = stringElements[0];
                string country = stringElements[1];
                int age = int.Parse(stringElements[2]);

                IPerson citizen = new Citizen(name, country, age);
                IResident citizen2 = new Citizen(name, country, age);
                Console.WriteLine(citizen.GetName());
                Console.WriteLine(citizen2.GetName());


            }


        }
    }
}
