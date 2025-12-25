using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter value in km : ");
        double km = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter value in miles : ");
        double miles = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter value in meter : ");
        double meter = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter value in feet : ");
        double feet = Convert.ToDouble(Console.ReadLine());

        double km2miles = ConvertKmToMiles(km);
        double miles2km = ConvertMilesToKm(miles);
        double meters2feet = ConvertMetertoFeet(meter);
        double feet2meters = ConvertFeetToMeter(feet);

        Console.WriteLine($"Km to miles : {km2miles:F2}");
        Console.WriteLine($"miles to km : {miles2km:F2}");
        Console.WriteLine($"meter to feet : {meters2feet:F2}");
        Console.WriteLine($"feet to meter : {feet2meters:F2}");
    }

    static double ConvertKmToMiles(double km)
    {
        double km2miles = 0.621371*km;
        return km2miles;
    }
    static double ConvertMilesToKm(double miles)
    {
        double miles2km = 1.60934*miles;
        return miles2km;
    }
    static double ConvertMetertoFeet(double meter)
    {
         double meters2feet = 3.28084*meter;
        return meters2feet;
    }
    static double ConvertFeetToMeter(double feet)
    {
        double feet2meters = 0.3048*feet;
        return feet2meters;
    }
}