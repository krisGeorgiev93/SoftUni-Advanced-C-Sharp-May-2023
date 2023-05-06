using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _2.Car_Extension
{
    public class Car
    {
        //fields
        private string make;
        private string model;
        private int year;
        private double fuelConsumption;
        private double fuelQuantity;

        //props
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model;} set { model = value; } }
        public int Year { get { return year; } set { year = value; } }
        public double FuelConsumption { get {return fuelConsumption; } set { fuelConsumption = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }   

        //Create void method
       public void Drive(double distance)
        {
            double neededFuel = distance * fuelConsumption;

            if (fuelQuantity - neededFuel > 0)
            {
                fuelQuantity -= neededFuel;
            }

            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        //Create string method
        public string WhoIAm()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"Fuel: {this.FuelQuantity:f2}");

            return result.ToString();
        }

    }
}
