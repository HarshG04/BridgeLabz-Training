using System;

class RectanglePerimeter
{
    static void Main(string[] args)
    {
        int l = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int perimeter = (l + b) * 2;
        Console.WriteLine(perimeter);
    }
}
