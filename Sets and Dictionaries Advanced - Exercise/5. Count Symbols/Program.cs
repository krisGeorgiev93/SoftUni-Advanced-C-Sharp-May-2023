using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> occurences = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (!occurences.ContainsKey(ch))
                {
                    occurences.Add(ch, 0);
                }
                occurences[ch]++;
            }

            foreach (var ch in occurences)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }

        }
    }
}
