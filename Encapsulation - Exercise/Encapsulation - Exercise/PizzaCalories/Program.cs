using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {

            //////Dough White Chewy 100

            ////Dough dough = new Dough("White", "Chewy", 100);

            ////Console.WriteLine($"{dough.Calorioes:f2}");

            ////Dough Tip500 Chewy 100
            ////Dough dough = new Dough("Tip500", "Chewy", 100);
            ////Topping meat 30

            //Topping topping = new Topping("Meat", 500);
            //Console.WriteLine(topping.Calories);


            string[] pizzaInfo = Console.ReadLine().Split();


            string[] doughInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string pizzaName = pizzaInfo[1];
                string typeDough = doughInfo[1];
                string techniqueDough = doughInfo[2];
                int gramsDough = int.Parse(doughInfo[3]);

                Dough dough = new Dough(typeDough, techniqueDough, gramsDough);


                Pizza pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppingInfo = input.Split();
                    string type = toppingInfo[1];
                    int grams = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(type, grams);

                    pizza.AddTopping(topping);


                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories:f2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
