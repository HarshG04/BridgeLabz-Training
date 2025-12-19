using System;

class FahrenheitToCelsius{
    static void Main(){
        double fahrenheit = double.Parse(Console.ReadLine());
        double celsiusResult = (fahrenheit - 32) * 5.0 / 9.0;

        Console.WriteLine("The " + fahrenheit + " Fahrenheit is " +celsiusResult + " Celsius");
    }
}
