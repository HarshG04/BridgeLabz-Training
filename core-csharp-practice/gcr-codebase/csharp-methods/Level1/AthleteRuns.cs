using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Sides of Triangular Park :");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());

        double rounds = ComputeRound(a,b,c);
        Console.WriteLine($"Rounds: {rounds:F2}");
    }

    static double ComputeRound(double a,double b,double c)
    {
        double perimeter = a+b+c;
        double round = 5000.0/perimeter;
        return round;
    }
}