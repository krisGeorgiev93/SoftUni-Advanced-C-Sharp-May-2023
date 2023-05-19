using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse));
            Dictionary<string, HashSet<char>> words = new Dictionary<string, HashSet<char>>()
            {
                 { "pear", new HashSet<char>() },
                { "flour",new HashSet<char>() },
                { "pork",new HashSet<char>() },
                { "olive", new HashSet<char>() },
            };

            while (consonants.Any())
            {
                char vowelLetter = vowels.Dequeue();
                char consonantLetter = consonants.Pop();
                foreach (var word in words)
                {
                    if (word.Key.Contains(vowelLetter))
                    {
                        word.Value.Add(vowelLetter);
                    }
                    if (word.Key.Contains(consonantLetter))
                    {
                        word.Value.Add(consonantLetter);
                    }
                }

                vowels.Enqueue(vowelLetter);
            }
            // new dictionary with all foundWords --> if word.Value.Count == word.Key.Length ====> 1 found word
            Dictionary<string, HashSet<char>> foundWords = new Dictionary<string, HashSet<char>>(words.Where(x => x.Value.Count == x.Key.Length));

            Console.WriteLine($"Words found: {foundWords.Count()}{Environment.NewLine}{string.Join(Environment.NewLine, foundWords.Keys)}");
        }
    }
}
