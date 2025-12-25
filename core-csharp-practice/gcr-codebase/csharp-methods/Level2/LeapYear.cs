using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        bool check = IsLeapYear(year);
    
        if (check) Console.WriteLine("Leap Year");
        else Console.WriteLine("Not a Leap Year");
    }

    static bool IsLeapYear(int year)
    {

        if (year < 1582)
        {
            Console.WriteLine("Year Less than 1582");
            Environment.Exit(0);
            return false;
        }
        
        else if (year % 400 == 0) return true;
        else if (year % 100 == 0) return false;
        else if (year % 4 == 0) return true;
        else return false;
    }
}