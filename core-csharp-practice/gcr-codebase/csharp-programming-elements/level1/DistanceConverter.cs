using System;

class DistanceConverter
{
    static void Main()
    {
       double distanceInFeet = double.Parse(Console.ReadLine());

        double distanceInYards = distanceInFeet / 3;
        double distanceInMiles = distanceInYards / 1760;

        Console.WriteLine("Distance in yards is " + distanceInYards +" and distance in miles is " + distanceInMiles);
    }
}