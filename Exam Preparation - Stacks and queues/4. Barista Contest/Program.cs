using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Barista_Contest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Dictionary<string, int> drinks = new Dictionary<string, int>();

            Queue<int> coffeQuantity = new Queue<int>(firstInput);
            Stack<int> milkQuantity = new Stack<int>(secondInput);
            
            while (coffeQuantity.Any() && milkQuantity.Any())
            {
                int sum = coffeQuantity.Peek() + milkQuantity.Peek();
                if (sum != 50 && sum != 75 && sum != 100 && sum != 150 && sum != 200)
                {
                    coffeQuantity.Dequeue();
                    int currentMilkQuantity = milkQuantity.Peek();
                    milkQuantity.Pop();
                    milkQuantity.Push(currentMilkQuantity - 5);
                }
                else
                {
                    if (sum == 50)
                    {
                        if (!drinks.ContainsKey("Cortado"))
                        {
                            drinks.Add("Cortado", 0);
                        }
                        drinks["Cortado"]++;
                        coffeQuantity.Dequeue();
                        milkQuantity.Pop();
                    }
                    if (sum == 75)
                    {
                        if (!drinks.ContainsKey("Espresso"))
                        {
                            drinks.Add("Espresso", 0);
                        }
                        drinks["Espresso"]++;
                        coffeQuantity.Dequeue();
                        milkQuantity.Pop();
                    }
                    if (sum == 100)
                    {
                        if (!drinks.ContainsKey("Capuccino"))
                        {
                            drinks.Add("Capuccino", 0);
                        }
                        drinks["Capuccino"]++;
                        coffeQuantity.Dequeue();
                        milkQuantity.Pop();
                    }
                    if (sum == 150)
                    {
                        if (!drinks.ContainsKey("Americano"))
                        {
                            drinks.Add("Americano", 0);
                        }
                        drinks["Americano"]++;
                        coffeQuantity.Dequeue();
                        milkQuantity.Pop();
                    }
                    if (sum == 200)
                    {
                        if (!drinks.ContainsKey("Latte"))
                        {
                            drinks.Add("Latte", 0);
                        }
                        drinks["Latte"]++;
                        coffeQuantity.Dequeue();
                        milkQuantity.Pop();
                    }
                }
            }

            if (coffeQuantity.Count == 0 && milkQuantity.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffeQuantity.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ",coffeQuantity)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milkQuantity.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milkQuantity)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var drink in drinks.OrderBy(x => x.Value).ThenByDescending(x=> x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
