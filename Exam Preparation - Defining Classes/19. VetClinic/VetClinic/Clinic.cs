using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }
        public List<Pet> data { get; set; }
        public int Count { get => data.Count; }

        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            var targetPet = data.FirstOrDefault(x=> x.Name == name);
            if (targetPet != null)
            {
                data.Remove(targetPet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name,string owner) => data.FirstOrDefault(x=> x.Name == name && x.Owner == owner);

        public Pet GetOldestPet() => data.OrderByDescending(x=> x.Age).FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();

        }


    }
}
