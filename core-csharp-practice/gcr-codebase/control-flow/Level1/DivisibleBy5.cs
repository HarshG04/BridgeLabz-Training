using System;
class Divisibility
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        bool ans = false;
        if(n%5==0) ans = true;
        System.Console.WriteLine("Is the number "+n+" divisible by 5? "+ans);
    }
}