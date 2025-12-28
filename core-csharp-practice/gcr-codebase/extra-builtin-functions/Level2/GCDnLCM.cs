using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int gcd = GCD(a, b);
        int lcm = LCM(a, b);

        Console.WriteLine($"GCD = {gcd}");
        Console.WriteLine($"LCM = {lcm}");
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static int LCM(int a, int b)
    {
        return Math.Abs(a * b) / GCD(a, b);
    }
}
