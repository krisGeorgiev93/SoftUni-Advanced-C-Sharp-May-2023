using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> occurences = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!occurences.ContainsKey(numbers[i]))
                {
                    occurences.Add(numbers[i], 0);
                }
                occurences[numbers[i]]++;

            }

            foreach (var number in occurences)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }





        }
    }
}
