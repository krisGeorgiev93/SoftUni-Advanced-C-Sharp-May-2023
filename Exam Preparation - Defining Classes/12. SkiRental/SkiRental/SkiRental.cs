using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Ski> data { get; set; }

        public bool Add(Ski ski)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(ski);
                return true;
            }
            return false;
        }

        public bool Remove(string manufacturer, string model)
        {
            var targetSki = data.FirstOrDefault(x=> x.Manufacturer == manufacturer && x.Model == model);
            if (targetSki != null)
            {
                data.Remove(targetSki);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki() => data.OrderByDescending(x=> x.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model) => data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

        public int Count => this.data.Count;

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"The skis stored in {this.Name}:");
            foreach (var ski in data)
            {
                stringBuilder.AppendLine(ski.ToString());
            }
            return stringBuilder.ToString().Trim();


        }

    }
}
