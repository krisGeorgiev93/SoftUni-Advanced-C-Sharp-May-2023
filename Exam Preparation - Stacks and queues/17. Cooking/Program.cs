using System;
using System.Collections.Generic;
using System.Linq;

namespace _16._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Dictionary<string, int> food = new Dictionary<string, int>()
            {
                {"Bread",0 },
                {"Cake",0 },
                {"Pastry",0 },
                {"Fruit Pie" ,0}
            };

            Queue<int> liquids = new Queue<int>(input1);
            Stack<int> ingredients = new Stack<int>(input2);

            while (liquids.Any() && ingredients.Any())
            {
                int liquidValue = liquids.Peek();
                int ingredientValue = ingredients.Peek();
                int sum = liquidValue + ingredientValue;
                switch (sum)
                {
                    case 25:
                        food["Bread"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 50:
                        food["Cake"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 75:
                        food["Pastry"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    case 100:
                        food["Fruit Pie"]++;
                        liquids.Dequeue();
                        ingredients.Pop();
                        break;
                    default:
                        {
                            liquids.Dequeue();
                            ingredients.Push(ingredients.Pop() + 3);
                        }
                        break;
                }
            }

            // Console.WriteLine(cookedFood.All(x => x.Value >= 1)
             //? "Wohoo! You succeeded in cooking all the food!"  IF IS TRUE
             //: "Ugh, what a pity! You didn't have enough materials to cook everything."); IF IS FALSE 
            if (food["Bread"] > 0 && food["Cake"] > 0 && food["Pastry"] > 0 && food["Fruit Pie"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }           
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }
            foreach (var item in food.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
