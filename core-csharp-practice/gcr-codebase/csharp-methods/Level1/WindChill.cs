using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Temp and Wind Speed : ");
        double temperature = Convert.ToDouble(Console.ReadLine());
        double windSpeed = Convert.ToDouble(Console.ReadLine());
        
        double windChill = CalculateWindChill(temperature,windSpeed);
        Console.WriteLine($"Wind Chill : {windChill:F2}");
    }

    static double CalculateWindChill(double temp, double windSpeed)
    {
       double windChill = 35.74 + 0.6215 *temp + (0.4275*temp - 35.75) * Math.Pow(windSpeed,0.16);
       return windChill;
    }

}