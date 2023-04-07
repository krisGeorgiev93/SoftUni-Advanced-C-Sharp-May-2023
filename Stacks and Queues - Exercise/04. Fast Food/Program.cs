using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> ordersQueue = new Queue<int>(orders);

            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Any())
            {
                foodQuantity -= ordersQueue.Peek();
                if (foodQuantity < 0)
                {
                    break;
                }
                ordersQueue.Dequeue();
            }
            if (ordersQueue.Any())
            {
                Console.Write($"Orders left: ");
                Console.Write(string.Join(" ",ordersQueue));
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
