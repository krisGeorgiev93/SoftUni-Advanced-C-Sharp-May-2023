using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> carsByName = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car();
                car.Model = input[0];
                car.FuelAmount = double.Parse(input[1]);
                car.FuelConsumptionPerKilometer = double.Parse(input[2]);
                carsByName.Add(car.Model, car);
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string carModel = tokens[1];
                double travelledDistance = double.Parse(tokens[2]);

                Car car = carsByName[carModel];
                car.Drive(travelledDistance);
            }

            foreach (var car in carsByName.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}