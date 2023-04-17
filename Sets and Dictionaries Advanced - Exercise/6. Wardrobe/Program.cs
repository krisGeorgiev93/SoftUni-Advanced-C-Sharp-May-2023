using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                string[] clothes = input[1].Split(",");
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }
                    wardrobe[color][item]++;
                }
            }

            string searchingClothes = Console.ReadLine();
            string[] tokens = searchingClothes.Split();
            string searchingColor = tokens[0];
            string searchingItem = tokens[1];
            foreach (var item in wardrobe)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var clothes in item.Value)
                {
                    if (wardrobe.ContainsKey(searchingColor) && wardrobe[searchingColor].ContainsKey(searchingItem))
                    {
                        if (searchingItem == clothes.Key && item.Key == searchingColor)
                        {
                            Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
           
            
        }
    }
}
