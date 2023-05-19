using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Rubber_Duck_Debuggers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Dictionary<string, int> ducks = new Dictionary<string, int>()
            {
                 { "Darth Vader Ducky", 0 },
                 { "Thor Ducky", 0 },
                 { "Big Blue Rubber Ducky", 0 },
                 { "Small Yellow Rubber Ducky", 0 }
            };

            //Your task is to count how many rubber ducks of each type you’ve given to your programmers.

            Queue<int> times = new Queue<int>(input1);
            Stack<int> tasks = new Stack<int>(input2);

            while (times.Any() && tasks.Any())
            {
                int timesValue = times.Peek();
                int tasksValue = tasks.Peek();

                int result = timesValue * tasksValue;

                if (result >= 0 && result <= 60)
                {
                    ducks["Darth Vader Ducky"]++;
                    times.Dequeue();
                    tasks.Pop();
                }
                if (result >= 61 && result <= 120)
                {
                    ducks["Thor Ducky"]++;
                    times.Dequeue();
                    tasks.Pop();
                }
                if (result >= 121 && result <= 180)
                {
                    ducks["Big Blue Rubber Ducky"]++;
                    times.Dequeue();
                    tasks.Pop();
                }
                if (result >= 181 && result <= 240)
                {
                    ducks["Small Yellow Rubber Ducky"]++;
                    times.Dequeue();
                    tasks.Pop();
                }

                //If the calculated time goes above the highest range, decrease the number of the task’s value by 2.
                //Then, move the programmer time's value to the end of its sequence, and continue with the next operation.
                if (result > 240)
                {
                    tasks.Push(tasks.Pop() - 2);
                    times.Dequeue();
                    times.Enqueue(timesValue);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck.Key}: {duck.Value}");
            }
        }
    }
}
