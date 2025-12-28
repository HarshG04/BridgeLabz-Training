using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first date (yyyy-MM-dd): ");
        DateTime d1 = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter second date (yyyy-MM-dd): ");
        DateTime d2 = DateTime.Parse(Console.ReadLine());

        if (d1 < d2)
            Console.WriteLine("First date is BEFORE second date");
        else if (d1 > d2)
            Console.WriteLine("First date is AFTER second date");
        else
            Console.WriteLine("Both dates are SAME");
    }
}
