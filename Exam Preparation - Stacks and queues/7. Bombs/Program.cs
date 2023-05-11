using System;
using System.Collections.Generic;
using System.Linq;

namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Dictionary<string, int> bombs = new Dictionary<string, int>();
            Queue<int> bombEffect = new Queue<int>(input1);
            Stack<int> bombCasing = new Stack<int>(input2);
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);

            while (bombEffect.Any() && bombCasing.Any())
            {

                int sum = bombEffect.Peek() + bombCasing.Peek();

                if (sum == 0)
                {
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    continue;
                }
                if (sum == 40)
                {
                    bombs["Datura Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }
                else if (sum == 60)
                {
                    bombs["Cherry Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();

                }
                else if (sum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                }

                else
                {
                    bombCasing.Push(bombCasing.Pop() - 5);
                }

                if (bombs["Datura Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3)
                {
                    break;
                }

            }

            if (bombs["Datura Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffect.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (bombCasing.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
