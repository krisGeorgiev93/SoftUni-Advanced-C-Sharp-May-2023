using DefiningClasses;
public class StartUp
{
    private static void Main(string[] args)
    {
        Person peter = new Person();
        peter.Name = "Peter";
        peter.Age = 18;

        Person george = new Person();
        george.Name = "George";
        george.Age = 20;

        Console.WriteLine($"{peter.Name} is {peter.Age} years old");
        Console.WriteLine($"{george.Name} is {george.Age} years old");
    }
}