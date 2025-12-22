using System;

class Program
{
    static void Main()
    {   Console.WriteLine("Enter a year");
        int year = Convert.ToInt32(Console.ReadLine());

        if (year >= 1582 && (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))) Console.WriteLine("Leap Year");
        else Console.WriteLine("Not a Leap Year");
    }
}
