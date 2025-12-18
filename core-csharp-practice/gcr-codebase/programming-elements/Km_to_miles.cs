using System;

class KmToMiles
{
    static void Main(string[] args)
    {
        int km = int.Parse(Console.ReadLine());
        double miles = km * 0.621371;
        Console.WriteLine(miles);
    }
}
