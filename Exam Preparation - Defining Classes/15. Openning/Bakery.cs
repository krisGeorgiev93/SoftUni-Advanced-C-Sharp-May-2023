using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Employee>();

        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Employee> data { get; set; }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name) => data.Remove(data.FirstOrDefault(x=> x.Name == name));

        public Employee GetOldestEmployee() => data.OrderByDescending(x=> x.Age).FirstOrDefault();

        public Employee GetEmployee(string name) => data.FirstOrDefault(x=> x.Name == name);

        public int Count => data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (var employee in data)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
