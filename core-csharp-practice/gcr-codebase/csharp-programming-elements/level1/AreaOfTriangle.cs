using System;

class AreaOfTriangle
{
    static void Main()
    {
        double baseInInches = double.Parse(Console.ReadLine());
        double heightInInches = double.Parse(Console.ReadLine());

        double areaInSqInches = 0.5 * baseInInches * heightInInches;
        double areaInSqCm = areaInSqInches * 6.4516;

        Console.WriteLine("The area of the triangle is " +areaInSqInches + " square inches and " +areaInSqCm + " square centimeters");
    }
}