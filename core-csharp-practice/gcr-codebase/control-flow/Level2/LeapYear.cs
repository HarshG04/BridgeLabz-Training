using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a year");
        int year = Convert.ToInt32(Console.ReadLine());
    
        if (year < 1582) Console.WriteLine("Not a Leap Year");
        else if (year % 400 == 0) Console.WriteLine("Leap Year");
        else if (year % 100 == 0) Console.WriteLine("Not a Leap Year");
        else if (year % 4 == 0) Console.WriteLine("Leap Year");
        else Console.WriteLine("Not a Leap Year");
    }
}
