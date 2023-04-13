using System;
using System.Collections.Generic;

namespace _7._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] tokens = input.Split(", ");
                string direction = tokens[0];
                string number = tokens[1];

                if (direction == "IN")
                {
                    if (!carNumbers.Contains(number))
                    {
                        carNumbers.Add(number);
                    }
                }
                else
                {
                    if (carNumbers.Contains(number))
                    {
                        carNumbers.Remove(number);
                    }
                }
            }
            if (carNumbers.Count>0)
            {
                foreach (var number in carNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
