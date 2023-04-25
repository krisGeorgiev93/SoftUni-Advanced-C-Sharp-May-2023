using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Apocalypse_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inpu2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> textiles = new Queue<int>(input1);
            Stack<int> medicaments = new Stack<int>(inpu2);

            SortedDictionary<string, int> healingItems = new SortedDictionary<string, int>();

           
            while (textiles.Any() && medicaments.Any())
            {
                int sum = (textiles.Peek() + medicaments.Peek());
                if (sum == 30)
                {
                    if (!healingItems.ContainsKey("Patch"))
                    {
                        healingItems.Add("Patch", 0);
                    }
                    healingItems["Patch"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                    continue;
                }
                if (sum == 40)
                {
                    if (!healingItems.ContainsKey("Bandage"))
                    {
                        healingItems.Add("Bandage", 0);
                    }
                    healingItems["Bandage"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                    continue;
                }
                if (sum == 100)
                {
                    if (!healingItems.ContainsKey("MedKit"))
                    {
                        healingItems.Add("MedKit", 0);
                    }
                    healingItems["MedKit"]++;
                    textiles.Dequeue();
                    medicaments.Pop();
                    continue;
                }                  
                
                if (sum > 100)
                {
                    if (!healingItems.ContainsKey("MedKit"))
                    {
                        healingItems.Add("MedKit", 0);
                    }
                    healingItems["MedKit"]++;
                    sum -= 100;
                    textiles.Dequeue();
                    medicaments.Pop();
                    medicaments.Push(medicaments.Pop() + sum);                    
                }
                else
                {
                    textiles.Dequeue();
                    medicaments.Push(medicaments.Pop() + 10);
                }

            }

            
            if (textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else
            {
                if (textiles.Count == 0)
                {
                    Console.WriteLine("Textiles are empty.");
                }
                if (medicaments.Count == 0)
                {
                    Console.WriteLine("Medicaments are empty.");
                }
            }

            if (healingItems.Any())
            {
                foreach (var item in healingItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }
            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}
