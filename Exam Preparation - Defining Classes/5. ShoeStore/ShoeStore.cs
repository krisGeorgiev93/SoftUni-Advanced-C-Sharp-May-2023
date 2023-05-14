using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {     

        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            this.Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }


        //make a getter
        public int Count => this.Shoes.Count;
        

        public string AddShoe(Shoe shoe)
        {
            if (this.StorageCapacity == this.Shoes.Count)
            {
                return "No more space in the storage room.";
            }

            this.Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int removedShoes = 0;

            for (int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material.ToLower())
                {
                    Shoes.RemoveAt(i--);
                    removedShoes++;
                }
            }

            return removedShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> listToReturn = new List<Shoe>();
            foreach (Shoe shoe in this.Shoes)
            {
                if (shoe.Type == type.ToLower())
                {
                    listToReturn.Add(shoe);
                }
            }
            return listToReturn;
        }

        public Shoe GetShoeBySize(double size) => this.Shoes.FirstOrDefault(s => s.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> stockList = this.Shoes.Where(s => s.Size == size && s.Type == type).ToList();

            StringBuilder sb = new StringBuilder();
            if (stockList.Count == 0)
            {
                sb.AppendLine("No matches found!");
            }
            else
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (Shoe shoe1 in stockList)
                {
                    sb.AppendLine(shoe1.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }



    }
}
