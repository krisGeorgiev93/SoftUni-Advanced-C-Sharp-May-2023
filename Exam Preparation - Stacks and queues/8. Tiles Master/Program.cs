using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> whiteTiles = new Stack<int>(input1);
            Queue<int> greyTiles = new Queue<int>(input2);

            Dictionary<string, int> locations = new Dictionary<string, int>();

            while (whiteTiles.Any() && greyTiles.Any())
            {
                int whiteTile = whiteTiles.Peek();
                int greyTile = greyTiles.Peek();

                if (whiteTile == greyTile)
                {
                    int sum = whiteTile + greyTile;
                    if (sum == 40)
                    {
                        if (!locations.ContainsKey("Sink"))
                        {
                            locations.Add("Sink", 0);
                        }
                        locations["Sink"]++;
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else if (sum == 50)
                    {
                        if (!locations.ContainsKey("Oven"))
                        {
                            locations.Add("Oven", 0);
                        }
                        locations["Oven"]++;
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else if (sum == 60)
                    {
                        if (!locations.ContainsKey("Countertop"))
                        {
                            locations.Add("Countertop", 0);
                        }
                        locations["Countertop"]++;
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else if (sum == 70)
                    {
                        if (!locations.ContainsKey("Wall"))
                        {
                            locations.Add("Wall", 0);
                        }
                        locations["Wall"]++;
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                    else
                    {
                        if (!locations.ContainsKey("Floor"))
                        {
                            locations.Add("Floor", 0);
                        }
                        locations["Floor"]++;
                        whiteTiles.Pop();
                        greyTiles.Dequeue();
                    }
                }

                else
                {
                    whiteTiles.Pop();
                    whiteTiles.Push(whiteTile / 2);
                    greyTiles.Dequeue();
                    greyTiles.Enqueue(greyTile);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ",whiteTiles)}");
            }
            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ",greyTiles)}");
            }

            foreach (var location in locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key)) // order by value then by name 
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
