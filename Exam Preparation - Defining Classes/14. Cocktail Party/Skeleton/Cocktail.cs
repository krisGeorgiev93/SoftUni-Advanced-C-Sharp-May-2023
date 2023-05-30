using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {



        public Cocktail(string name, int capacity, int maxAlcoholLevel) 
        {
            this.Name = name;   
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
        }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Contains(ingredient) && Ingredients.Count < Capacity && ingredient.Quantity < MaxAlcoholLevel)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            var targetIngedient = Ingredients.FirstOrDefault(x=> x.Name == name);
            if (targetIngedient != null)
            {
                Ingredients.Remove(targetIngedient);
                return true;
            }
            return false;
        }
        public Ingredient FindIngredient(string name) => Ingredients.FirstOrDefault(x=> x.Name == name);

        public Ingredient GetMostAlcoholicIngredient() => Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();

        public int CurrentAlcoholLevel => this.Ingredients.Sum(x => x.Alcohol);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
