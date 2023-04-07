using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boxes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int capacityOfRack = int.Parse(Console.ReadLine());
            int totalRacks = 1;
            int currentRack = capacityOfRack;
            Stack<int> stack = new Stack<int>(boxes);

            while (stack.Any())
            {
                if (currentRack - stack.Peek() >= 0)
                {
                    currentRack -= stack.Pop();                   
                }
                else
                {
                    totalRacks++;
                    currentRack = capacityOfRack;
                    currentRack -= stack.Pop();
                }
            }

            Console.WriteLine(totalRacks);
        }
    }
}
