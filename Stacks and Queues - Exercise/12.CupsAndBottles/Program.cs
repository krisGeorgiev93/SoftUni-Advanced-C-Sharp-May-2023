using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(
     Console.ReadLine()
         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
         .Select(int.Parse)
         .ToArray());

            Stack<int> bottles = new Stack<int>(
                Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int cup = cups.Dequeue();
                int bottle = bottles.Pop();

                cup -= bottle;

                if (cup <= 0)
                {
                    wastedWater += Math.Abs(cup);
                    continue;
                }

                while (cup > 0 && bottles.Any())
                {
                    bottle = bottles.Pop();
                    cup -= bottle;

                    if (cup <= 0)
                    {
                        wastedWater += Math.Abs(cup);
                        break;
                    }
                }
            }

            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
