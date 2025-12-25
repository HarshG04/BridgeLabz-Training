using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter Number of Students : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int max = MaxHandshakes(n);
        Console.WriteLine($"No of max handshakes : {max}");
    }

    static int MaxHandshakes(int n)
    {
        int max = (n*(n-1))/2;
        return max;
    }
}