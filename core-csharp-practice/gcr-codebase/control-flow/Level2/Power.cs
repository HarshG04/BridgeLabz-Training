using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter power: ");
        int pow = Convert.ToInt32(Console.ReadLine());

        int res = 1;

        for (int i = 1; i <= pow; i++)
            res *= num;

        Console.WriteLine(res);
    }
}
