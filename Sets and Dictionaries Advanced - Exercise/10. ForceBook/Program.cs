using System;
using System.Collections.Generic;
using System.Linq;
namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, SortedSet<string>> forceBook = new Dictionary<string, SortedSet<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string username = tokens[1];
                    if (!forceBook.Values.Any(u => u.Contains(username)))
                    {
                        if (!forceBook.ContainsKey(side))
                        {
                            forceBook.Add(side, new SortedSet<string>());
                        }

                        forceBook[side].Add(username);
                    }
                }
                if (input.Contains("->"))
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string username = tokens[0];
                    string side = tokens[1];
                    foreach (var sideUsers in forceBook)
                    {
                        if (sideUsers.Value.Contains(username))
                        {
                            sideUsers.Value.Remove(username);
                            break;
                        }
                    }
                    if (!forceBook.ContainsKey(side))
                    {
                        forceBook.Add(side, new SortedSet<string>());
                    }
                    forceBook[side].Add(username);
                    Console.WriteLine($"{username} joins the {side} side!");
                }
            }

            Dictionary<string, SortedSet<string>> orderedSidesUsers = forceBook
    .OrderByDescending(s => s.Value.Count).ThenBy(s=> s.Key)
    .ToDictionary(s => s.Key, s => s.Value);

            foreach (var currentSide in orderedSidesUsers)
            {
                if (currentSide.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {currentSide.Key}, Members: {currentSide.Value.Count}");
                    foreach (var curUser in currentSide.Value)
                    {
                        Console.WriteLine($"! {curUser}");
                    }
                }
            }



        }
    }
}
