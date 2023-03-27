using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string stringValue = System.Console.ReadLine();

            int intValue = int.Parse(System.Console.ReadLine());

            if (intValue <= 15)
            {
                Child child = new Child(stringValue, intValue);
                Console.WriteLine(child);
            }
            else
            {
                Person person = new Person(stringValue, intValue);
                Console.WriteLine(person);
            }

            

        }
    }
}