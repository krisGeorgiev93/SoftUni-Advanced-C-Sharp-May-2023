using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ").ToArray();

            Queue<string> queue = new Queue<string>(songs);
            string command = string.Empty;
            while (queue.Any())
            {
                command = Console.ReadLine();
                string[] commandParts = command.Split();
                string commandType = commandParts[0];

                if (commandType == "Play")
                {
                    queue.Dequeue();
                }
                if (commandType == "Add")
                {
                    string song = string.Join(" ", commandParts.Skip(1));
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                if (commandType == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }


            }
            Console.WriteLine("No more songs!");

        }
    }
}
