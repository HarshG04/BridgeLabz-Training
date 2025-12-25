using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter month (1–12): ");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter year: ");
        int y = Convert.ToInt32(Console.ReadLine());

        string monthName = GetMonthName(m);
        int daysInMonth = GetDaysInMonth(m, y);
        int firstDay = GetFirstDayOfMonth(m, y);

        Console.WriteLine($"\n{monthName} {y}");
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        for (int i = 0; i < firstDay; i++) Console.Write("    ");

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,3} ");

            if ((day + firstDay) % 7 == 0) Console.WriteLine();
        }

        Console.WriteLine();
    }

    static string GetMonthName(int m)
    {
        string[] months ={"January","February","March","April","May","June","July","August","September","October","November","December"};
        return months[m - 1];
    }

    static bool IsLeapYear(int y)
    {
        return (y % 400 == 0) || (y % 4 == 0 && y % 100 != 0);
    }

    static int GetDaysInMonth(int m, int y)
    {
        int[] days = {31, 28, 31, 30, 31, 30,31, 31, 30, 31, 30, 31 };

        if (m == 2 && IsLeapYear(y)) return 29;

        return days[m - 1];
    }
    static int GetFirstDayOfMonth(int m, int y)
    {   
        int d = 1;
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;
        return d0;
    }
}
