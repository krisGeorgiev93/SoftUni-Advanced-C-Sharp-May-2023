using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace _3._Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {           

            double[] input1 = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] input2 = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(input1);
            Stack<double> flour = new Stack<double>(input2);
            SortedDictionary<string, int> bakeryProducts = new SortedDictionary<string, int>();

            while (water.Any() && flour.Any())
            {
                double sum = water.Peek() + flour.Peek();
                double waterPercentage = water.Peek() / sum * 100;
                double flourPercentage = flour.Peek() / sum * 100;

                if (waterPercentage == 50 && flourPercentage == 50)
                {
                    if (!bakeryProducts.ContainsKey("Croissant"))
                    {
                        bakeryProducts.Add("Croissant", 0);
                    }
                    bakeryProducts["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                    continue;
                }
                if (waterPercentage == 40 && flourPercentage == 60)
                {
                    if (!bakeryProducts.ContainsKey("Muffin"))
                    {
                        bakeryProducts.Add("Muffin", 0);
                    }
                    bakeryProducts["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                    continue;
                }
                if (waterPercentage == 20 && flourPercentage == 80)
                {
                    if (!bakeryProducts.ContainsKey("Bagel"))
                    {
                        bakeryProducts.Add("Bagel", 0);
                    }
                    bakeryProducts["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                    continue;
                }
                if (waterPercentage == 30 && flourPercentage == 70)
                {
                    if (!bakeryProducts.ContainsKey("Baguette"))
                    {
                        bakeryProducts.Add("Baguette", 0);
                    }
                    bakeryProducts["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                    continue;
                }

                else
                {
                    if (!bakeryProducts.ContainsKey("Croissant"))
                    {
                        bakeryProducts.Add("Croissant", 0);
                    }
                    bakeryProducts["Croissant"]++;
                    double flourReduced = flour.Pop() - water.Dequeue();
                    flour.Push(flourReduced);
                }

            }

            foreach (var product in bakeryProducts.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }
            if (water.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flour.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
