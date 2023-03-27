using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] numberInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach (var number in numberInfo)
            {
                ICallable callable = null;
                if (number.Any(c => !char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    if (number.Length == 7)
                    {
                        callable = new StationaryPhone();
                    }
                    else if (number.Length == 10)
                    {
                        callable = new Smartphone();
                    }
                    callable.Call(number);
                }

            }
            foreach (var site in websites)
            {
                IBrowsable browsable = null;
                if (site.Any(c => char.IsDigit(c)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    browsable = new Smartphone();
                    browsable.Browse(site);
                }



            }
        }
    }
}
