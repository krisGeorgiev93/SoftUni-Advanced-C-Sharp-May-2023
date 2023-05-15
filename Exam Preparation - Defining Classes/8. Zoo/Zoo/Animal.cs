﻿using System.Text;

namespace Zoo
{
    public class Animal
    {
        public Animal(string species, string diet, double weight, double length)
        {
            this.Species = species;
            this.Diet = diet;
            this.Weight = weight;
            this.Length = length;
        }

        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.Species} is a {this.Diet} and weighs {this.Weight} kg.");
            return sb.ToString().Trim();        
        }
    }
}
