using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           SortedSet<string> uniqueElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split().ToArray();
                foreach (var item in elements)
                {
                    uniqueElements.Add(item);
                }
            }

            Console.WriteLine(string.Join(" ",uniqueElements));
        }
    }
}
