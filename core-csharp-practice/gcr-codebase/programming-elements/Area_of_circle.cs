using System;

class AreaOfCircle
{
    static void Main(string[] args)
    {
        int r = int.Parse(Console.ReadLine());

        double pi = 3.14;
        double area = pi * r * r;
        Console.WriteLine(area);
    }
}
