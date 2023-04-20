namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordAndFrequency = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    string[] wordsInCurrentLine = currentLine.ToLower().Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' },
                        StringSplitOptions.RemoveEmptyEntries);
                    string[] words = File.ReadAllText(wordsFilePath).Split();

                    foreach (var word in words)
                    {
                        foreach (var currentWord in wordsInCurrentLine)
                        {
                            if (word == currentWord)
                            {
                                if (!wordAndFrequency.ContainsKey(word))
                                {
                                    wordAndFrequency.Add(word, 0);
                                }
                                wordAndFrequency[word]++;
                            }
                        }
                    }
                    currentLine = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordAndFrequency.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
