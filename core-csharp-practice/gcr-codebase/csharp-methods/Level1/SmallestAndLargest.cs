using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Three Numbers: ");
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        int[] ans =  FindSmallestAndLargest(a,b,c);
        Console.WriteLine($"Smallest  Number : {ans[0]}");
        Console.WriteLine($"Largest  Number : {ans[1]}");

    }

    public static int[] FindSmallestAndLargest(int a, int b, int c)
    {
        int[] ans = new int[2];
        ans[0] = Math.Min(a,Math.Min(b,c));
        ans[1] = Math.Max(a,Math.Max(b,c));

        return ans;
    }
}