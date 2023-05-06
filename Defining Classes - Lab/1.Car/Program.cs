namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "GOLF";
            car.Year = 1999;

            Console.WriteLine($"{car.Make}\n{ car.Model}\n{car.Year}");
        }
    }
}