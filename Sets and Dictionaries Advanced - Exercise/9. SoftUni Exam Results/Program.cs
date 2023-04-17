using System;
using System.Collections.Generic;
using System.Linq;
namespace _9._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            SortedDictionary<string, int> participantsPoints = new SortedDictionary<string, int>();
            SortedDictionary<string, int> languagesSubmissions = new SortedDictionary<string, int>();

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = input.Split("-");
                string name = tokens[0];
                string language = tokens[1];
                if (language == "banned")
                {
                    participantsPoints.Remove(name);
                    continue;
                }

                int points = int.Parse(tokens[2]);
                 
                if (!participantsPoints.ContainsKey(name))
                {
                    participantsPoints.Add(name, 0);
                }

                if (participantsPoints[name] < points)
                {
                    participantsPoints[name] = points;
                }


                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions.Add(language, 0);
                }
                languagesSubmissions[language]++;

            }

            Console.WriteLine("Results:");
            foreach (var participant in participantsPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var submission in languagesSubmissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{submission.Key} - {submission.Value}");
            }

        }
    }
}
