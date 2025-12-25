using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter x1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = Convert.ToDouble(Console.ReadLine());

        double distance = EuclideanDistance(x1, y1, x2, y2);
        Console.WriteLine($"\nEuclidean Distance = {distance:F4}");

        double[] line = EquationOfLine(x1, y1, x2, y2);

        if (double.IsInfinity(line[0])) Console.WriteLine("The line is vertical. Equation: x = " + x1);
        else Console.WriteLine($"Line Equation: y = {line[0]:F4} * x + {line[1]:F4}");
    }

    static double EuclideanDistance(double x1, double y1, double x2, double y2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;

        return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
    }

    static double[] EquationOfLine(double x1, double y1, double x2, double y2)
    {
        double[] res = new double[2];

        double m = (y2 - y1) / (x2 - x1);
        double b = y1 - m * x1;

        res[0] = m;
        res[1] = b;

        return res;
    }
}
