using System;

class Power
{
    static void Main(string[] args)
    {
        int baseNum = int.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());

        double ans = Math.Pow(baseNum, power);
        Console.WriteLine(ans);
    }
}
