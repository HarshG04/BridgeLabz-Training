using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Number and Divisor: ");
        int num = Convert.ToInt32(Console.ReadLine());
        int div = Convert.ToInt32(Console.ReadLine());
        

        int[] ans =  FindRemainderAndQuotient(num,div);
        Console.WriteLine($"quotient  : {ans[0]}");
        Console.WriteLine($"reminder : {ans[1]}");

    }

    public static int[] FindRemainderAndQuotient(int num, int div)
    {
        int[] ans = new int[2];
        ans[0] = num/div;
        ans[1] = num%div;

        return ans;
    }
}