using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.Drones = new List<Drone>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public List<Drone> Drones { get; set; }


        public int Count => this.Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (Drones.Count >= Capacity)
            {
                return "Airfield is full.";
            }

            if (drone.Name == null || drone.Brand == null)
            {
                return "Invalid drone.";
            }
            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var targetDrone = Drones.FirstOrDefault(x => x.Name == name);

            if (targetDrone == null)
            {
                return false;
            }
            this.Drones.Remove(targetDrone);
            return true;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;
            while (this.Drones.FirstOrDefault(x => x.Brand == brand) != null)
            {
                var targetDrone = this.Drones.FirstOrDefault(x => x.Brand == brand);
                Drones.Remove(targetDrone);
                count++;
            }
            return count;
        }

        public Drone FlyDrone(string name)
        {
            var targetDrone = this.Drones.FirstOrDefault(x => x.Name == name);
            if (targetDrone == null)
            {
                return null;
            }
            targetDrone.Available = false;
            return targetDrone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> flyDrones = new List<Drone>();
            for (int i = 0; i < Drones.Count; i++)
            {
                if (Drones[i].Range >= range)
                {
                    flyDrones.Add(Drones[i]);
                    Drones.RemoveAt(i--);
                }
            }

            return flyDrones;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Drones available at {Name}:");
            foreach (var drone in this.Drones.Where(x => x.Available == true))
            {
                stringBuilder.AppendLine(drone.ToString());
            }
            return stringBuilder.ToString().TrimEnd();


        }


    }
}
