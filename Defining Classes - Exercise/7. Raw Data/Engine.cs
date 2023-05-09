using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Engine
    {
        //Constructor
       public Engine(int speed, int power) 
        {
            this.Speed = speed;
            this.Power = power;               
        }

        //props
        public int Speed { get; set; }
        public int Power { get; set; }


    }
}
