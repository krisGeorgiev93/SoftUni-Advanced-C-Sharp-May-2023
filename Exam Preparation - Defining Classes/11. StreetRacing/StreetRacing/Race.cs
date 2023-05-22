using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            this.Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public List<Car> Participants { get; set; }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (Participants.Count < Capacity)
            {
                if (Participants.All(x => x.LicensePlate != car.LicensePlate))
                {
                    if (car.HorsePower <= this.MaxHorsePower)
                    {
                        Participants.Add(car);
                    }
                }
            }
        }

        public bool Remove(string licensePlate)
        {
            var targetCar = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            if (targetCar == null)
            {
                return false;
            }
            this.Participants.Remove(targetCar);
            return true;

        }

        public Car FindParticipant(string licensePlate)
        {
            foreach (var item in Participants.Where(X => X.LicensePlate == licensePlate))
            {
                return item;
            }

            return null;
        }

        public Car GetMostPowerfulCar() => Participants.OrderByDescending(x => x.HorsePower).FirstOrDefault();

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            if (Participants.Any())
            {
                foreach (var car in Participants)
                {
                    stringBuilder.AppendLine(car.ToString());
                }
            }

            return stringBuilder.ToString().Trim();
        }


    }
}
