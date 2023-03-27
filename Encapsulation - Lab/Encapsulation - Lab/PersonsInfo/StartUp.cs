using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int intValue = int.Parse(Console.ReadLine());


            List<Person> persons = new List<Person>();

            for (int i = 0; i < intValue; i++)
            {

                try
                {
                    string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string firstName = stringElements[0];
                    string lastName = stringElements[1];
                    int age = int.Parse(stringElements[2]);
                    decimal salary = decimal.Parse(stringElements[3]);

                    Person curPerson = new Person(firstName, lastName, age, salary);
                    persons.Add(curPerson);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            //decimal persentage = decimal.Parse(Console.ReadLine());

            //persons.ForEach(p => p.IncreaseSalary(persentage));

            //persons.ForEach(p => Console.WriteLine(p));

            Team team = new Team("SoftUni");

            foreach (var person in persons)
            {

                team.AddPlayer(person);

            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");



            

        }
    }
}
