using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n<0) Console.WriteLine("The number "+ n+" is not a natural number");
        else{
            double sum = ((n)*(n+1))/2.0;
            double total = 0.0;
            for(int i=1;i<=n;i++) total += i;
            System.Console.WriteLine("The sum of "+n+" natural numbers is Using Formula: "+sum);
            System.Console.WriteLine("The sum of "+n+" natural numbers is Using Formula for Loop: "+total);
        }
    }
}