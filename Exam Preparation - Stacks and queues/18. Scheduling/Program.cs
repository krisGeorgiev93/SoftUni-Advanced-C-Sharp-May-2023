using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _18._Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int task = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(input1);
            Queue<int> threads = new Queue<int>(input2);
            bool neededTask = false;
            //If the thread value is greater than or equal to the task value, the task and thread get removed.
            //If the thread value is less than the task value, the thread gets removed, but the task remains.
            int lastThread = 0;
            while (!neededTask)
            {
                int taskValue = tasks.Peek();
                int threadValue = threads.Peek();
                if (taskValue == task)
                {
                    lastThread = threadValue;
                    neededTask = true;
                    break;
                }
                if (threadValue >= taskValue)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {lastThread} killed task {task}");
            Console.WriteLine(string.Join(" ", threads));
        }
    }
}
