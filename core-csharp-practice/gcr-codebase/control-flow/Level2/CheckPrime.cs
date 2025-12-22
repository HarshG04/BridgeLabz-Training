using System;

class Program
{
     static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        bool isPrime = true;

        if(n<=1) Console.WriteLine("Number is less than 2");
        else
        {
            for(int i = 2; i < n; i++) 
                if(n%i==0)
                {
                    isPrime = false;
                    break;
                }
            
            if(isPrime) Console.WriteLine("Prime Number");
            else Console.WriteLine("Not a Prime Number");


            
        }
    }
}