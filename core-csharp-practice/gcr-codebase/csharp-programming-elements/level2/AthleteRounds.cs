using System;

class AthleteRounds
{
    static void Main()
    {
        Console.Write("Enter side 1 (meters): ");
        double side1 = double.Parse(Console.ReadLine());

        Console.Write("Enter side 2 (meters): ");
        double side2 = double.Parse(Console.ReadLine());

        Console.Write("Enter side 3 (meters): ");
        double side3 = double.Parse(Console.ReadLine());

        double perimeter = side1 + side2 + side3;
        double rounds = 5000 / perimeter;

        Console.WriteLine("The total number of rounds the athlete will run is " + rounds +" to complete 5 km");
    }
}
