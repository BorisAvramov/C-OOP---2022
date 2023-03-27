using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
      public  static void Main(string[] args)
        {
            //List <IIdentifiable> identifiables = new List <IIdentifiable>();

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "End")
            //    {
            //        break;
            //    }
            //    string[] stringElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //    if (stringElements.Length == 3)
            //    {
            //        string name = stringElements[0];
            //        int age = int.Parse(stringElements[1]);
            //        string id = stringElements[2];
            //        IIdentifiable citizen = new Citizen(name, age, id);
            //        identifiables.Add(citizen);
            //    }
            //    else if (stringElements.Length == 2)
            //    {
            //        string model = stringElements[0];
            //        string id = stringElements[1];
            //       IIdentifiable robot = new Robot(model, id);
            //        identifiables.Add(robot);
            //    }

            //}
            //string lastDigits = Console.ReadLine();

            //foreach (var item in identifiables)
            //{
            //    if (item.Id.EndsWith(lastDigits))
            //    {
            //        Console.WriteLine(item.Id);
            //    }
            //}
            //====================================================================================
            //List<IIdentifiable> identifiables = new List<IIdentifiable>();
            //List<IBirthable> birthable = new List<IBirthable>();

            //while (true)
            //{
            //    string input = Console.ReadLine();
            //    if (input == "End")
            //    {
            //        break;
            //    }
            //    string[] stringElements = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //    if (stringElements[0] == "Citizen")
            //    {
            //        string name = stringElements[1];
            //        int age = int.Parse(stringElements[2]);
            //        string id = stringElements[3];
            //        string birthDate = stringElements[4];
            //        IIdentifiable citizen = new Citizen(name, age, id);
            //        IBirthable citizenBirthable = new Citizen(name, age, id, birthDate);
            //        identifiables.Add(citizen);
            //        birthable.Add(citizenBirthable);
            //    }
            //    else if (stringElements[0] == "Robot")
            //    {
            //        string model = stringElements[0];
            //        string id = stringElements[1];
            //        IIdentifiable robot = new Robot(model, id);
            //        identifiables.Add(robot);
            //    }
            //    else if (stringElements[0] == "Pet")
            //    {
            //        string name = stringElements[1];
            //        string birthDate = stringElements[2];
            //        IBirthable pet = new Pet(name, birthDate);
            //        birthable.Add(pet);
            //    }

            //}
            //string year = Console.ReadLine();

            //foreach (var item in birthable)
            //{
            //    if (item.BirthDate.EndsWith(year))
            //    {
            //        Console.WriteLine(item.BirthDate);
            //    }

            //}
            //=======================================================================================


            int intValue = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();


            for (int i = 0; i < intValue; i++)
            {

                string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (stringElements.Length == 4)
                {
                    IBuyer citizen = new Citizen(stringElements[0], int.Parse(stringElements[1]), stringElements[2], stringElements[3]);
                    buyers.Add(citizen);

                }
                else if (stringElements.Length == 3)
                {
                    IBuyer rebel = new Rebel(stringElements[0] ,int.Parse(stringElements[1]), stringElements[2]);
                    buyers.Add(rebel);
                }

            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                foreach (var buyer in buyers)
                {
                    
                    if (buyer.Name == input)
                    {
                        buyer.BuyFood();
                        break;
                    }
                }

            }
            int totalFood = 0;
            foreach (var buyer in buyers)
            {
                totalFood += buyer.Food;


            }
            Console.WriteLine(totalFood);
        }
    }
}
