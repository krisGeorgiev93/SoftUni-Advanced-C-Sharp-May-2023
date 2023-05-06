using _2.Car_Extension;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {

            Car car = new Car();
            car.Make = "BMW";
            car.Model = "X3";
            car.Year = 2008;

            car.FuelQuantity = 100;
            car.FuelConsumption = 2;

            car.Drive(10);
            car.Drive(1000);

            Console.WriteLine(car.WhoIAm());

        }
    }
}