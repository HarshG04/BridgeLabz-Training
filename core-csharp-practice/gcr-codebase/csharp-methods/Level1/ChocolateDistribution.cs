using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Number of Chocolates and Children: ");
        int numberOChocolates  = Convert.ToInt32(Console.ReadLine());
        int numberOfChildren = Convert.ToInt32(Console.ReadLine());
        

        int[] ans =  FindRemainderAndQuotient(numberOChocolates,numberOfChildren);
        Console.WriteLine($"number of chocolates each child will get  : {ans[0]}");
        Console.WriteLine($"remaining chocolates : {ans[1]}");

    }

    public static int[] FindRemainderAndQuotient(int num, int div)
    {
        int[] ans = new int[2];
        ans[0] = num/div;
        ans[1] = num%div;

        return ans;
    }
}