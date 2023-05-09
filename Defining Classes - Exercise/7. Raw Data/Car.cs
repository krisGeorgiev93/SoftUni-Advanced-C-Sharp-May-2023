using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._Raw_Data
{
    public class Car
    {
        public Car(
        string model,
        int speed,
        int power,
        int weight,
        string type,
        double tyre1pressure,
        int tyre1age,
        double tyre2pressure,
        int tyre2age,
        double tyre3pressure,
        int tyre3age,
        double tyre4pressure,
        int tyre4age)
        {
            Model = model;
            Engine = new Engine(speed, power);
            Cargo = new Cargo(type, weight);
            Tyres = new Tyre[4];
            Tyres[0] = new Tyre(tyre1pressure, tyre1age);
            Tyres[1] = new Tyre(tyre2pressure, tyre2age);
            Tyres[2] = new Tyre(tyre3pressure, tyre3age);
            Tyres[3] = new Tyre(tyre4pressure, tyre4age);
        }

        //props
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tyre[] Tyres { get; set; }


    }
}
