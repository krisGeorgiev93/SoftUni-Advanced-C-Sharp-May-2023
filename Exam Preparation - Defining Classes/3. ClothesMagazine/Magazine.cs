using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public List<Cloth> Clothes { get; set; } = new List<Cloth>();

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }

        }

        public bool RemoveCloth(string color)
        {
            var cloth = Clothes.FirstOrDefault(x => x.Color == color);

            if (cloth == null)
            {
                return false;
            }
            Clothes.Remove(cloth);
            return true;
        }

        public Cloth GetSmallestCloth() => this.Clothes.OrderBy(c => c.Size).FirstOrDefault();

        public Cloth GetCloth(string color) => this.Clothes.FirstOrDefault(c => c.Color == color);

        public int GetClothCount() => this.Clothes.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Type} magazine contains:");

            foreach (var cloth in this.Clothes.OrderBy(c => c.Size))
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd();
        }


    }
}
