using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            int[] platesOfDefense = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> plates = new Queue<int>(platesOfDefense);
            Stack<int> orcs = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                orcs = new Stack<int>(input);
                if (i % 3 == 0)
                {
                    int singlePlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(singlePlate);
                }              

                while (orcs.Any() && plates.Any())
                {
                    

                    if (orcs.Peek() > plates.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Peek());
                        plates.Dequeue();
                        if (plates.Count == 0)
                        {
                            break;
                        }
                    }
                    else if (plates.Peek() > orcs.Peek())
                    {
                        List<int> platesList = plates.ToList();
                        plates.Clear();
                        platesList[0] -= orcs.Peek();
                        foreach (var plate in platesList)
                        {
                            plates.Enqueue(plate);
                        }
                        orcs.Pop();
                    }
                    else
                    {
                        orcs.Pop();
                        plates.Dequeue();                        
                    }
                }               
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            }
            if (orcs.Any())
            {
                Console.WriteLine($"Orcs left: {(string.Join(", ", orcs))}");
            }
            if (plates.Any())
            {
                Console.WriteLine($"Plates left: {(string.Join(", ", plates))}");
            }
        }
    }
}
