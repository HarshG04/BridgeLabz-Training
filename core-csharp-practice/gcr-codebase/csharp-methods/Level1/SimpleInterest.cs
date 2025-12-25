using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Enter Principal Amount, Rate and Time");
        double p = Convert.ToDouble(Console.ReadLine());
        double r = Convert.ToDouble(Console.ReadLine());
        double t = Convert.ToDouble(Console.ReadLine());

        double si = SimpleInterest(p,r,t);
        Console.WriteLine($"The Simple Interest is {si} for Principal {p}, Rate of Interest {r} and Time {t}");
    }

    static double SimpleInterest(double p,double r, double t)
    {
        double si = (p*r*t)/100;
        return si;
    }
}
