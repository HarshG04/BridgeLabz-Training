using System;

class SimpleInterest
{
    static void Main(string[] args)
    {
        int p = int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());
        int t = int.Parse(Console.ReadLine());

        double si = (p * r * t) / 100.0;
        Console.WriteLine(si);
    }
}
