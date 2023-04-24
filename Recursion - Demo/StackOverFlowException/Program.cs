using System;

namespace StackOverFlowException
{
    class Program
    {
        static void Main(string[] args)
        {
            StackOverflowSux();
        }

         static unsafe void StackOverflowSux()
        {
            int x = 5;
            Console.WriteLine((int)&x);
            StackOverflowSux();
        }
    }
}
