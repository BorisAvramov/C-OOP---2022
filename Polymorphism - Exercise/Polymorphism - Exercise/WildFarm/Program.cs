using System;
using System.Collections.Generic;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] animalInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);
                Animal animal = null;
                Food food = null;

                if (animalInfo[0] == "Owl")
                {
                    animal = new Owl(name, weight, double.Parse(animalInfo[3]));
         
                }
                if (animalInfo[0] == "Hen")
                {
                    animal = new Hen(name, weight, double.Parse(animalInfo[3]));
                }
                if (animalInfo[0] == "Mouse")
                {
                    animal = new Mouse(name, weight, animalInfo[3]);
                }
                if (animalInfo[0] == "Cat")
                {
                    animal = new Cat(name, weight, animalInfo[3], animalInfo[4]);
                }
                if (animalInfo[0] == "Dog")
                {
                    animal = new Dog(name, weight, animalInfo[3]);
                }
                if (animalInfo[0] == "Tiger")
                {
                    animal = new Tiger(name, weight, animalInfo[3], animalInfo[4]);
                }

                if (foodInfo[0] == "Vegetable")
                {
                    food = new Vegetable(int.Parse(foodInfo[1]));
                }
                if (foodInfo[0] == "Fruit")
                {
                    food = new Fruit(int.Parse(foodInfo[1]));
                }
                if (foodInfo[0] == "Meat")
                {
                    food = new Meat(int.Parse(foodInfo[1]));
                }
                if (foodInfo[0] == "Seeds")
                {
                    food = new Seeds(int.Parse(foodInfo[1]));
                }
                Console.WriteLine(animal.ProducedSound());
                animal.Feed(food);
                animals.Add(animal);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
            
        }
    }
}
