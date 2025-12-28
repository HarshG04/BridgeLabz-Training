using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Celsius to Fahrenheit");
        Console.WriteLine("2. Fahrenheit to Celsius");
        Console.Write("Choose option: ");

        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter Celsius: ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Fahrenheit = " + CelsiusToFahrenheit(c));
        }
        else if (choice == 2)
        {
            Console.Write("Enter Fahrenheit: ");
            double f = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Celsius = " + FahrenheitToCelsius(f));
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }

    static double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }

    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }
}
