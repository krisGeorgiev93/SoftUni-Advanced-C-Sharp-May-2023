using System;
using System.Collections.Generic;
using System.Linq;

namespace _14._Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> sets = new Queue<int>();
            Stack<int> hats = new Stack<int>(input1);
            Queue<int> scarfs = new Queue<int>(input2);

            while (hats.Any() && scarfs.Any())
            {
                int hatValue = hats.Peek();
                int scarfValue = scarfs.Peek();
                if (hatValue > scarfValue)
                {
                    int set = hatValue + scarfValue;
                    sets.Enqueue(set);
                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (hatValue < scarfValue)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ",sets));
        }
    }
}
