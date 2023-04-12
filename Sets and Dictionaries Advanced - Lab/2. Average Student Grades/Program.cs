using System;
using System.Collections.Generic;
using System.Linq;
namespace _2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string name = tokens[0];
                decimal grade = decimal.Parse(tokens[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());                    
                }
                students[name].Add(grade);

            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.Write($"(avg: {student.Value.Average():f2})");
                Console.WriteLine();
            }



        }
    }
}
