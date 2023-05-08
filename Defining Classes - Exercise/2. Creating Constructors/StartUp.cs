using DefiningClasses;
using System;

public class StartUp
{
    private static void Main(string[] args)
    {
        Person person = new Person();
        person.Name = "Peter";
        person.Age = 18;

        
        Console.WriteLine($"{person.Name} is {person.Age} years old");
    }
}