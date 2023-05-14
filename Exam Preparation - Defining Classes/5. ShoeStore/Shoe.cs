namespace ShoeStore
{
    public class Shoe
    {
        public Shoe(string brand , string type, double size, string material) 
        {
            this.Brand = brand;
            this.Type = type;
            this.Size = size;
            this.Material = material;
        }


        public string Brand { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        public string Material { get; set; }

        public override string ToString()
        {
            return $"Size {Size}, {Material} {Brand} {Type} shoe.".TrimEnd();
        }


    }
}
