using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsInfo = new Dictionary<string, string>();

            SortedDictionary<string, Dictionary<string, int>> internsInfo = new SortedDictionary<string, Dictionary<string, int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine())!= "end of contests")
            {
                string[] tokens = input.Split(":");
                string contest = tokens[0];
                string password = tokens[1];
                if (!contestsInfo.ContainsKey(contest))
                {
                    contestsInfo.Add(contest, password);
                }
            }

            string results = string.Empty;
            while ((results= Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = results.Split("=>");
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestsInfo.ContainsKey(contest) && contestsInfo[contest] == password) 
                {
                    if (!internsInfo.ContainsKey(username))
                    {
                        internsInfo.Add(username, new Dictionary<string, int>());
                        internsInfo[username].Add(contest,points);
                    }
                    if (!internsInfo[username].ContainsKey(contest))
                    {
                        internsInfo[username].Add(contest, points);
                    }
                    if (internsInfo[username][contest] < points)
                    {
                        internsInfo[username][contest] = points;
                    }
                }
            }

            string bestCandidate = internsInfo
              .OrderByDescending(c => c.Value.Values.Sum())
              .First().Key;

            //string bestCandidate = candidatesStats.MaxBy(c => c.Value.Values.Sum()).Key;

            int bestCandidateTotalPoints = internsInfo[bestCandidate].Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidateTotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var currentCandidat in internsInfo)
            {
                Console.WriteLine($"{currentCandidat.Key}");

                Dictionary<string, int> orderedByPoints = currentCandidat.Value.OrderByDescending(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
                foreach (var contest in orderedByPoints)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
