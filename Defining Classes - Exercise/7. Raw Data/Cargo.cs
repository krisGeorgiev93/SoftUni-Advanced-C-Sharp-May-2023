using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Cargo
    {
        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public int Weight { get; set; }
        public string Type { get; set; }


    }
}
