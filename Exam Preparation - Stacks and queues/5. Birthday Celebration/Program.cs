using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebration
{
    internal class Program
    {
        static void Main()
        {
            var guests = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            var meals = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            int wastedfood = 0;

            int currentGuest = guests.Peek();
            int currentMeal = meals.Peek();

            while (guests.Count > 0 && meals.Count > 0)
            {
                currentGuest -= currentMeal;
                if (currentGuest > 0)
                {
                    meals.Pop();
                    if (meals.Count == 0)
                    {
                        break;
                    }
                    currentMeal = meals.Peek();
                }
                else
                {
                    wastedfood += Math.Abs(currentGuest);
                    guests.Dequeue();
                    meals.Pop();
                    if (guests.Count == 0 || meals.Count == 0)
                    {
                        break;
                    }
                    currentGuest = guests.Peek();
                    currentMeal = meals.Peek();
                }
            }

            if (meals.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ', meals)}");
            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedfood}");
        }
    }
}