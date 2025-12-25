using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter value in yards : ");
        double yards = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter value in feet : ");
        double feet = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter value in meters : ");
        double meters = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter value in inches : ");
        double inches = Convert.ToDouble(Console.ReadLine());

        double yards2feet = UnitConverter.ConvertYardsToFeet(yards);
        double feet2yards = UnitConverter.ConvertFeetToYards(feet);
        double meters2inches = UnitConverter.ConvertMetersToInches(meters);
        double inches2meters = UnitConverter.ConvertInchesToMeters(inches);
        double inches2cm = UnitConverter.ConvertInchesToCentimeters(inches);

        Console.WriteLine($"Yards to feet : {yards2feet:F2}");
        Console.WriteLine($"Feet to yards : {feet2yards:F2}");
        Console.WriteLine($"Meters to inches : {meters2inches:F2}");
        Console.WriteLine($"Inches to meters : {inches2meters:F2}");
        Console.WriteLine($"Inches to centimeters : {inches2cm:F2}");
    }
}

static class UnitConverter
{
    public static double ConvertYardsToFeet(double yards) {
        return 3 * yards;
    }

    public static double ConvertFeetToYards(double feet) {
        return 0.333333 * feet;
    }

    public static double ConvertMetersToInches(double meters) {
        return 39.3701 * meters;
    }

    public static double ConvertInchesToMeters(double inches) {
        return 0.0254 * inches;
    }

    public static double ConvertInchesToCentimeters(double inches) {
        return 2.54 * inches;
    }
}
