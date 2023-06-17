
using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            this.Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if(Capacity > Vehicles.Count)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            var targetCar = Vehicles.FirstOrDefault(x=> x.VIN == vin);
            if (targetCar != null)
            {
                Vehicles.Remove(targetCar);
                return true;
            }
            return false;
        }

        public int GetCount() => Vehicles.Count;

        public Vehicle GetLowestMileage() => Vehicles.OrderBy(x => x.Mileage).First();

        public string Report()
        {
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendLine("Vehicles in the preparatory:");
            foreach (var item in Vehicles)
            {
                stringbuilder.AppendLine(item.ToString());
            }
            return stringbuilder.ToString().TrimEnd();
        }
    }
}
