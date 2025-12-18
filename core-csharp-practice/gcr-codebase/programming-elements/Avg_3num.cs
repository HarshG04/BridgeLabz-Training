using System;

class Avg_3num
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        double avg = (a + b + c) / 3.0;
        Console.WriteLine(avg);
    }
}
