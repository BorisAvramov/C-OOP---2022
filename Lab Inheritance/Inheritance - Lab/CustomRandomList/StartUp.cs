using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {



            RandomList myList = new RandomList();
            myList.Add("koko");
            myList.Add("mimi");
            myList.Add("pesho");
            myList.Remove("pesho");

            Console.WriteLine( myList.RandomString());


            //myList.Add("borko");

        }
    }
}
