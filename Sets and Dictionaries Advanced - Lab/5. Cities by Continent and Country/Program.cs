using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> data = new Dictionary<string, Dictionary<string, List<string>>>();


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string contintent = tokens[0];
                string country = tokens[1];
                string city = tokens[2];

                if (!data.ContainsKey(contintent))
                {
                    data.Add(contintent, new Dictionary<string, List<string>>());
                }
                if (!data[contintent].ContainsKey(country))
                {
                    data[contintent].Add(country, new List<string>());
                }
                data[contintent][country].Add(city);
            }

            foreach (var continent in data)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ", country.Value)}");
                }
            }



        }
    }
}
