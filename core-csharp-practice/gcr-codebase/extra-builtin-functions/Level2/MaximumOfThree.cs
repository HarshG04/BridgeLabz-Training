using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Three Numbers : ");
        int n = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        int l = Convert.ToInt32(Console.ReadLine());
        int max = FindMax(n,m,l);
        Console.WriteLine($"Maxium : {max}");
    }

    static int FindMax(int n,int m,int l)
    {
        return Math.Max(l,Math.Max(n,m));
    }
}