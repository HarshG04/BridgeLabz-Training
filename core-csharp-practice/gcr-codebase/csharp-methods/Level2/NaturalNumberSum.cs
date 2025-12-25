using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = NaturalSum(n);
        int sum1 = NaturalSum1(n);

        Console.WriteLine($"Sum using recursion : {sum}\nSum Using Formula : {sum1}");



    }
    static int NaturalSum(int n)
    {
        if(n<=0) return 0;
        int sum = NaturalSum(n-1);
        return sum+n;
    }

    static int NaturalSum1(int n)
    {
        int sum = ((n)*(n+1))/2;
        return sum;
    }
}