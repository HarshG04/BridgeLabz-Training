using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Month, Day and Year: ");
        int m = Convert.ToInt32(Console.ReadLine());
        int d = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());

        int yy = y - (14 - m) / 12;
        int x = yy + yy / 4 - yy / 100 + yy / 400;
        int mm = m + 12 * ((14 - m) / 12) - 2;
        int dd = (d + x + (31 * mm) / 12) % 7;

        Console.WriteLine(dd);
    }
}
