using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            Console.WriteLine( stack.IsEmpty());

            stack.Push("Koko");
            stack.Push("sofi");
            stack.Push("suzi");


            Console.WriteLine(stack);

        }
    }
}
