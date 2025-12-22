using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n<0) Console.WriteLine("The number "+ n+" is not a Positive number");
        else{
            int fact = 1;
            for(int i=1;i<=n;i++) fact *= i;
            System.Console.WriteLine("Fact is: "+fact);
        }
    }
}