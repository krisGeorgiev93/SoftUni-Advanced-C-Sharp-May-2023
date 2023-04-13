using System;
using System.Collections.Generic;

namespace _8._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "PARTY")
                {
                    input = Console.ReadLine();
                    while (input != "END")
                    {
                        if (vipGuests.Contains(input))
                        {
                            vipGuests.Remove(input);
                        }
                        if (regularGuests.Contains(input))
                        {
                            regularGuests.Remove(input);
                        }
                        input = Console.ReadLine();
                    }
                }
                if (input == "END")
                {
                    break;
                }
                char[] name = input.ToCharArray();
                if (char.IsDigit(name[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }
            }

            int total = regularGuests.Count + vipGuests.Count;

            Console.WriteLine(total);

            if (vipGuests.Count > 0)
            {
                foreach (var vipGuest in vipGuests)
                {
                    Console.WriteLine(vipGuest);
                }
            }
            if (regularGuests.Count > 0)
            {
                foreach (var regularGuest in regularGuests)
                {
                    Console.WriteLine(regularGuest);
                }
            }
        }
    }
}
