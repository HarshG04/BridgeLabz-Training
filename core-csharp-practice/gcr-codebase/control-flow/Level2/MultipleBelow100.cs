using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        for (int i = 100; i >= 1; i--)
        {
            if (i % number == 0) Console.WriteLine(i);
        }
    }
}
