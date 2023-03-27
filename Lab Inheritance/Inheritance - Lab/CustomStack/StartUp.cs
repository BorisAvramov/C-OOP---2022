using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine(stack.IsEmpty());

            stack.Push("Koko");
            stack.Push("sofi");
            stack.Push("suzi");

            stack.AddRange(new List<string> { "borko", "mimi"});
            
            Console.WriteLine(stack.IsEmpty());
            Console.WriteLine(stack);
        }
    }
}
