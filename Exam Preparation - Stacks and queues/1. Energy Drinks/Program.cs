using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Energy_Drinks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] milligramsOfCaffein = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] energyDrinks = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> milligrams = new Stack<int>(milligramsOfCaffein);
            Queue<int> drinks = new Queue<int>(energyDrinks);

            //To calculate the caffeine in the drink take the last milligrams of caffeinе and the first energy drink,
            //and multiply them. Then, compare the result with the caffeine Stamat drank
            int maxCaffein = 300;
            int currentCaffein = 0;

            while (milligrams.Any() && drinks.Any())
            {
                if (milligrams.Peek() * drinks.Peek() + currentCaffein > maxCaffein )
                {
                    milligrams.Pop();
                    int drink = drinks.Dequeue();
                    drinks.Enqueue(drink);
                    currentCaffein -= 30;
                    if (currentCaffein < 0)
                    {
                        currentCaffein = 0;
                    }
                }
                else
                {
                    currentCaffein += (milligrams.Pop() * drinks.Dequeue());
                }
            }

            if (drinks.Any())
            {
                Console.WriteLine($"Drinks left: {(string.Join(", ",drinks))}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {currentCaffein} mg caffeine.");



        }
    }
}
