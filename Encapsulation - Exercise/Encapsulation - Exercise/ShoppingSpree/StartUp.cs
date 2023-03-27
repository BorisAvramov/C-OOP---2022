using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string,Person> persons = new Dictionary<string, Person>();

            Dictionary<string, Product> products = new Dictionary<string, Product>();



            string[] personsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < personsInfo.Length; i++)
                {

                    string[] nameMoney = personsInfo[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    Person curPerson = new Person(nameMoney[0], decimal.Parse(nameMoney[1]));
                    if (!persons.ContainsKey(nameMoney[0]))
                    {
                        persons.Add(nameMoney[0], curPerson);
                    }

                }
                for (int i = 0; i < productsInfo.Length; i++)
                {
                    string[] nameCost = productsInfo[i].Split('=', StringSplitOptions.RemoveEmptyEntries);
                    Product curProduct = new Product(nameCost[0], decimal.Parse(nameCost[1]));

                    if (!products.ContainsKey(nameCost[0]))
                    {
                        products.Add(nameCost[0], curProduct);
                    }
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = commandInfo[0];
                    string productName = commandInfo[1];

                    persons[personName].Buy(products[productName]);
                    command = Console.ReadLine();
                }

                foreach (var (name, person) in persons)
                {
                    string output = person.BagOfProducts.Count > 0 ?
                        $"{string.Join(", ", person.BagOfProducts.Select(p=>p.Name))}"
                        : "Nothing bought";

                    Console.WriteLine($"{person.Name} - {output}");

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

           

        }
    }
}
