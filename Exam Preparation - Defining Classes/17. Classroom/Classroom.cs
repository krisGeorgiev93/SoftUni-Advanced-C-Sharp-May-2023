using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student> ();
        }


        public int Capacity { get; set; }
        public int Count { get =>  students.Count; }
        public List<Student> students { get; set; }

        public int GetStudentsCount() => students.Count;
            
        public string RegisterStudent(Student student)
        {
            if(students.Count < this.Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var targetStudent = students.FirstOrDefault(x=> x.FirstName == firstName && x.LastName == lastName);
            if (targetStudent != null)
            {
                students.Remove(targetStudent);
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var findStudents = students.FindAll(x=> x.Subject ==  subject);

            if (findStudents.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (var student in findStudents)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }

        public Student GetStudent(string firstName, string lastName) => students.FirstOrDefault(x=> x.FirstName == firstName && x.LastName == lastName);
    }
}
