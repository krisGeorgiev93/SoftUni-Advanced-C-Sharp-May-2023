using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace _4._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Revision")
                {
                    break;
                }
                string[] tokens = command.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop].Add(product, price);
            }

            foreach (var shop in shops.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var item in shop.Value)
{
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }



        }
    }
}
