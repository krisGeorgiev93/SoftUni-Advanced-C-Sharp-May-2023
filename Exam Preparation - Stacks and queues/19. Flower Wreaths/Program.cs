using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _19._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();


            Queue<int> roses = new Queue<int>(input1);
            Stack<int> lilies = new Stack<int>(input2);
            int storedFlowers = 0;

            int wreaths = 0;

            while (roses.Any() && lilies.Any())
            {
                int rose = roses.Peek();
                int lilie = lilies.Peek();
                int result = rose + lilie;
                if (result == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                    lilies.Pop();
                }
                else if (result > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                else
                {
                    storedFlowers += result;
                    roses.Dequeue();
                    lilies.Pop();
                }
                if (wreaths == 5)
                {
                    break;
                }
            }

            if (storedFlowers >= 15)
            {
                while (storedFlowers >= 15)
                {
                    storedFlowers -= 15;
                    wreaths++;
                }
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
            }
        }
    }
}
