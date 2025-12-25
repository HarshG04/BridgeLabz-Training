using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter a number : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = CalculateSum(n);
        Console.WriteLine(sum);
    }

    static int CalculateSum(int n)
    {
        int sum = 0;
        for(int i=1;i<=n;i++) sum+=i;
        return sum;
    }
}