namespace FishingNet
{
    public class Fish
    {
        public Fish(string fishtype, double length, double weight)
        {
            this.FishType = fishtype;
            this.Length = length;
            this.Weight = weight;
        }

        public string FishType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }

        public override string ToString()
        {
            return $"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.";
        }
    }
}
