using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Car> data { get; set; }


        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            var targetCar = data.FirstOrDefault(x=> x.Manufacturer == manufacturer && x.Model == model);
            if (targetCar != null)
            {
                data.Remove(targetCar);
                return true;
            }
            return false;
        }

        public Car GetLatestCar() => data.OrderByDescending(x => x.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model) => data.FirstOrDefault(x=> x.Manufacturer == manufacturer && x.Model == model);

        public int Count { get => data.Count; }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();

        }

    }
}
