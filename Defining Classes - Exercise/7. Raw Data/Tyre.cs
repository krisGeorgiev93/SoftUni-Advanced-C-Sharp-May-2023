using System;
using System.Collections.Generic;
using System.Text;

namespace _7._Raw_Data
{
    public class Tyre
    {
        public Tyre (double pressure,int age)
        {
            this.Pressure = pressure; 
            this.Age = age;
        }

        public double Pressure { get; set; }
        public int Age { get; set; }
    }
}
