using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        for (int i = 1; i < num; i++)
        {
            if (num % i == 0) sum += i;
        }

        if (sum > num) Console.WriteLine("Abundant Number");
        else Console.WriteLine("Not an Abundant Number");
    }
}