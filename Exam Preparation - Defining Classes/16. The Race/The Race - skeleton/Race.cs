using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        
        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Racer>();   
        }


        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> data;

        public void Add(Racer Racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            var targetRacer = data.FirstOrDefault(x => x.Name == name);
            if (targetRacer != null)
            {
                data.Remove(targetRacer);
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer() => data.OrderByDescending(x => x.Age).FirstOrDefault();

        public Racer GetRacer(string name) => data.FirstOrDefault(x => x.Name == name);

        public Racer GetFastestRacer() => data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();

        public int Count => data.Count;

        public string Report()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var racer in data)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }




    }
}
