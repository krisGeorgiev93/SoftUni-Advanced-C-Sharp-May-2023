using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9._Pokemon_Trainer
{
    public class Pokemon
    {
        public Pokemon(string name,string element,int health) 
        {
            PokemonName = name;
            Element = element;
            Health = health;      
        
        }

        public string PokemonName { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
