using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stack<int> whiteTileStack = new Stack<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));



            Queue<int> greyTilesQueue = new Queue<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));


            Dictionary<string, int> dictLoc = new Dictionary<string, int>();

            dictLoc.Add("Sink", 0);
            dictLoc.Add("Oven", 0);
            dictLoc.Add("Countertop", 0);
            dictLoc.Add("Wall", 0);
            dictLoc.Add("Floor", 0);

            while (whiteTileStack.Count > 0 && greyTilesQueue.Count > 0)
            {
                int curWhite = whiteTileStack.Peek();
                int curGrey = greyTilesQueue.Peek();

                if (curWhite == curGrey)
                {
                    int sum = curGrey + curWhite;

                    if (sum == 40)
                    {
                        dictLoc["Sink"]++;
                    }
                    else if (sum == 50)
                    {
                        dictLoc["Oven"]++;
                    }
                    else if (sum == 60)
                    {
                        dictLoc["Countertop"]++;
                    }
                   else if (sum == 70)
                    {
                        dictLoc["Wall"]++;
                    }
                    else
                    {
                        dictLoc["Floor"]++;
                    }

                    whiteTileStack.Pop();
                    greyTilesQueue.Dequeue();



                }
                else
                {
                    curWhite = curWhite / 2;
                    whiteTileStack.Pop();
                    whiteTileStack.Push(curWhite);

                    greyTilesQueue.Dequeue();
                    greyTilesQueue.Enqueue(curGrey);

                }



            }

            if (!whiteTileStack.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTileStack)}");
            }

            if (!greyTilesQueue.Any())
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTilesQueue)}");
            }

            foreach (var (key, value) in dictLoc.OrderByDescending(l => l.Value).ThenBy(l => l.Key))
            {
                if (value > 0)
                {
                    Console.WriteLine($"{key}: {value}");
                }
               


            }

        }
    }
}
