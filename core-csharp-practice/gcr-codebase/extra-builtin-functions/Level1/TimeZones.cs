using System;

class Program
{
    static void Main()
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;

        TimeZoneInfo ist = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
        TimeZoneInfo pst = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        Console.WriteLine("Current Time:");

        Console.WriteLine("GMT : " + now);
        Console.WriteLine("IST : " + TimeZoneInfo.ConvertTime(now, ist));
        Console.WriteLine("PST : " + TimeZoneInfo.ConvertTime(now, pst));
    }
}
