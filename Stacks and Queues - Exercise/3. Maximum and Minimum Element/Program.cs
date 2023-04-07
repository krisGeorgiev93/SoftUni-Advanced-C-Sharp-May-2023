using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            string command = string.Empty;

            for (int i = 0; i < n; i++)
            {

                command = Console.ReadLine();
                string[] commandParts = command.Split();
                if (commandParts[0] == "1")
                {
                    int number = int.Parse(commandParts[1]);
                    stack.Push(number);
                }
                if (commandParts[0] == "2")
                {
                    stack.Pop();
                }
                if (commandParts[0] == "3")
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                if (commandParts[0] == "4")
                {
                    if (stack.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
