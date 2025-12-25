using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter a number : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int checkNum = CheckNumber(n);
        switch (checkNum)
        {
            case 0 : Console.WriteLine($"number {n} is Zero");
            break;
            case 1 : Console.WriteLine($"number {n} is Positive");
            break;
            default : Console.WriteLine($"number {n} is Negative");
            break;
        }
    }

    static int CheckNumber(int n)
    {
        if(n>0) return 1;
        else if(n<0) return -1;
        else return 0;
    }
}