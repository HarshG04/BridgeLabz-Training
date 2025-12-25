using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter value of a : ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter value of b : ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter value of c : ");
        double c = Convert.ToDouble(Console.ReadLine());

        double[] roots = FindRoots(a, b, c);

        if (roots.Length == 0)
        {
            Console.WriteLine("No real roots (Delta is negative)");
        }
        else if (roots.Length == 1)
        {
            Console.WriteLine($"Only one root : {roots[0]:F2}");
        }
        else
        {
            Console.WriteLine($"Root 1 : {roots[0]:F2}");
            Console.WriteLine($"Root 2 : {roots[1]:F2}");
        }
    }

    static double[] FindRoots(double a, double b, double c)
    {
        double delta = Math.Pow(b, 2) - 4 * a * c;

        if (delta > 0)
        {
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return [ root1, root2 ];
        }
        else if (delta == 0)
        {
            double root = -b / (2 * a);
            return [root] ;
        }
        else
        {
            return [0]; // no real roots
        }
    }
}
