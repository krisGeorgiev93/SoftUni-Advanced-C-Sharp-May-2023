using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.fish = new List<Fish>();
        }

        public string Material { get; set; }
        public int Capacity { get; set; }
        public List<Fish> fish { get; set; }



        public int Count => this.fish.Count;

        public string AddFish(Fish fish)
        {

            if (string.IsNullOrWhiteSpace(fish.FishType) ||
                 fish.Length <= 0 ||
                 fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (this.fish.Count >= Capacity)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var targetFish = this.fish.FirstOrDefault(x => x.Weight == weight);
            if (targetFish == null)
            {
                return false;
            }
            this.fish.Remove(targetFish);
            return true;
        }

        public Fish GetFish(string fishType) => this.fish.FirstOrDefault(x => x.FishType == fishType);

        public Fish GetBiggestFish()
        {
            var longestFish = this.fish.Max(e => e.Length);
            var fish = this.fish.FirstOrDefault(e => e.Length == longestFish);
            return fish;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Into the {Material}:");
            foreach (var currentFish in this.fish.OrderByDescending(x => x.Length))
            {
                stringBuilder.AppendLine(currentFish.ToString());
            }
            return stringBuilder.ToString().Trim();

        }


    }
}
