using System;

class VolumeOfCylinder
{
    static void Main(string[] args)
    {
        int r = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        double pi = 3.14;
        double volume = pi * r * r * h;
        Console.WriteLine(volume);
    }
}
