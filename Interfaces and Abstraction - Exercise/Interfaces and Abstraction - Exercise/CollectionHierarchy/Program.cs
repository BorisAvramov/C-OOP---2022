using System;

namespace CollectionHierarchy
{
    public class Program
    {
       public static void Main(string[] args)
        {

            string[] stringElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int numRemove = int.Parse(Console.ReadLine());

            AddCollection addCollection = new AddCollection();

            for (int i = 0; i < stringElements.Length; i++)
            {

                Console.Write( addCollection.Add(stringElements[i]) + " ");
                

            }
            Console.WriteLine();
            AddRemoveCollection addRemoveCollection  = new AddRemoveCollection();
            for (int i = 0; i < stringElements.Length; i++)
            {

                Console.Write(addRemoveCollection.Add(stringElements[i]) + " ");


            }


            Console.WriteLine();
            MyList myList = new MyList();

            for (int i = 0; i < stringElements.Length; i++)
            {

                Console.Write(myList.Add(stringElements[i]) + " ");


            }
            Console.WriteLine();
            for (int i = 0; i < numRemove; i++)
            {

                Console.Write(addRemoveCollection.Remove() + " ");


            }
            Console.WriteLine();
            for (int i = 0; i < numRemove; i++)
            {

                Console.Write(myList.Remove() + " ");


            }
        }
    }
}
