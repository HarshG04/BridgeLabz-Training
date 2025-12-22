using System;
class Divisibility
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n==0) Console.WriteLine("Zero");
        else if(n>0) Console.WriteLine("Positive");
        else Console.WriteLine("Negative");
    }
}