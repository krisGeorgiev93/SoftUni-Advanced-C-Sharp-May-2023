using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _13._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(input1);
            Stack<int> secondBox = new Stack<int>(input2);
            int claimedItems = 0;

            while (firstBox.Any() && secondBox.Any())
            {
                int firstValue = firstBox.Peek();
                int secondValue = secondBox.Peek();
                int result = firstValue + secondValue;
                if (result % 2 == 0)
                {
                    claimedItems += result;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    int value = secondBox.Pop();
                    firstBox.Enqueue(value);
                }
            }
            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
