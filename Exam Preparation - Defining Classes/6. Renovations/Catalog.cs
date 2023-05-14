using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;
            this.renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public List<Renovator> renovators;

        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (renovators.Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return $"Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";


        }

        public bool RemoveRenovator(string name)
        {
            var currentName = this.renovators.FirstOrDefault(x => x.Name == name);
            if (currentName == null)
            {
                return false;
            }

            this.renovators.Remove(currentName);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            var result = 0;
            while (this.renovators.FirstOrDefault(x => x.Type == type) != null)
            {
                var targetRenovator = this.renovators.FirstOrDefault(x => x.Type == type);
                this.renovators.Remove(targetRenovator);
                result++;
            }
            return result;
        }

        public Renovator HireRenovator(string name)
        {
            var targetRenovator = this.renovators.FirstOrDefault(x => x.Name == name);
            if (targetRenovator == null)
            {
                return null;
            }

            targetRenovator.Hired = true;
            return targetRenovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> paidRenovators = new List<Renovator>();
            foreach (var item in this.renovators.Where(x => x.Days >= days))
            {
                paidRenovators.Add(item);
            }
            return paidRenovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            List<Renovator> notHired = new List<Renovator>();
            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Hired == false)
                {
                    notHired.Add(renovators[i]);
                }
            }
            if (notHired.Count > 0)
            {
                foreach (var renovator in notHired)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
