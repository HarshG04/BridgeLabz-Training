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
            while(n>0) total += (n--);
            System.Console.WriteLine("The sum of "+n+" natural numbers is Using Formula: "+sum);
            System.Console.WriteLine("The sum of "+n+" natural numbers is Using Formula While Loop: "+total);
        }
    }
}