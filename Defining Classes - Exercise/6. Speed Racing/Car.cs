
namespace SpeedRacing
{
    public class Car
    {
        //fields
        private string model;
        private double fuelAmount;
        private double fuelConsumtionPerKm;
        private double travelledDistance;

        //props
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public double FuelAmount 
        { get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer 
        {
            get { return this.fuelConsumtionPerKm; }
            set { this.fuelConsumtionPerKm = value; }
        }
        public double TravelledDistance 
        {
            get { return this.travelledDistance; }
            set { this.travelledDistance = value; }
       }

        //method
        public void Drive(double distance)
        {
            if (distance * FuelConsumptionPerKilometer > fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                FuelAmount -= distance * FuelConsumptionPerKilometer;
                TravelledDistance += distance;
            }
        }


    }
}
