using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _13._Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

          
            Queue<int> ingredients = new Queue<int>(input1);
            Stack<int> freshness = new Stack<int>(input2);

            Dictionary<string,int> dishes = new Dictionary<string,int>();

            while (ingredients.Any() && freshness.Any())
            {
                int ingredientValue = ingredients.Peek();
                int freshnessValue = freshness.Peek();
                int result = ingredientValue * freshnessValue;
                if (ingredients.Peek() == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                if (result == 150)
                {
                    if (!dishes.ContainsKey("Dipping sauce"))
                    {
                        dishes.Add("Dipping sauce", 0);
                    }
                    dishes["Dipping sauce"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }
                else if (result == 250)
                {
                    if (!dishes.ContainsKey("Green salad"))
                    {
                        dishes.Add("Green salad", 0);
                    }
                    dishes["Green salad"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }
               else if (result == 300)
                {
                    if (!dishes.ContainsKey("Chocolate cake"))
                    {
                        dishes.Add("Chocolate cake", 0);
                    }
                    dishes["Chocolate cake"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }
                else if (result == 400)
                {
                    if (!dishes.ContainsKey("Lobster"))
                    {
                        dishes.Add("Lobster", 0);
                    }
                    dishes["Lobster"]++;
                    freshness.Pop();
                    ingredients.Dequeue();
                }

                else
                {
                    freshness.Pop();                   
                    int value = ingredients.Peek() + 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(value);
                }
            }

            if (dishes.Values.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Any())
            {
                int sum = 0;
                foreach (var ingr in ingredients)
                {
                    sum += ingr;
                }
                Console.WriteLine($" Ingredients left: {sum}");
            }

            foreach (var dish in dishes.OrderBy(x=> x.Key))
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}
