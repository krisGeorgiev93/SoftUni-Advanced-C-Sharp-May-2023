using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6._Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Dictionary<string, int> swords = new Dictionary<string, int>();

            Queue<int> steel = new Queue<int>(input1);
            Stack<int> carbon = new Stack<int>(input2);


            while (steel.Any() && carbon.Any())
            {
                int sum = steel.Peek() + carbon.Peek();

                if (sum == 70)
                {
                    if (!swords.ContainsKey("Gladius"))
                    {
                        swords.Add("Gladius", 0);
                    }
                    swords["Gladius"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                if (sum == 80)
                {
                    if (!swords.ContainsKey("Shamshir"))
                    {
                        swords.Add("Shamshir", 0);
                    }
                    swords["Shamshir"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                if (sum == 90)
                {
                    if (!swords.ContainsKey("Katana"))
                    {
                        swords.Add("Katana", 0);
                    }
                    swords["Katana"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                if (sum == 110)
                {
                    if (!swords.ContainsKey("Sabre"))
                    {
                        swords.Add("Sabre", 0);
                    }
                    swords["Sabre"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                if (sum == 150)
                {
                    if (!swords.ContainsKey("Broadsword"))
                    {
                        swords.Add("Broadsword", 0);
                    }
                    swords["Broadsword"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                if(sum != 70 && sum != 80 && sum != 90&& sum != 110 && sum != 150)
                {
                    steel.Dequeue();
                    int value = carbon.Peek();
                    carbon.Pop();
                    carbon.Push(value+5);
                }
            }
            if (swords.Count > 0)
            {
                int total = 0;
                foreach (var item in swords.Values)
                {
                    total += item;
                }
                Console.WriteLine($"You have forged {total} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ",steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ",carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

            if (swords.Count > 0)
            {
                foreach (var item in swords.OrderBy(x=> x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
