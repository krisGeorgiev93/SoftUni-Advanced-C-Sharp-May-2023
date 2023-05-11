using System.Drawing;
using System.Text;

namespace ClothesMagazine
{
    public class Cloth
    {
        public Cloth(string color, int size, string type)
        {
            this.Color = color;
            this.Size = size;
            this.Type = type;
        }

        public string Color { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            sb.Append($"Product: {this.Type} with size {this.Size}, color {this.Color}");
            return sb.ToString().Trim();
        }

    }
}
