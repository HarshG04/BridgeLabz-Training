using System;

class CelsiusToFahrenheit
{
    static void Main(string[] args)
    {
        int c = int.Parse(Console.ReadLine());
        int f = (c * 9 / 5) + 32;
        Console.WriteLine(f);
    }
}
