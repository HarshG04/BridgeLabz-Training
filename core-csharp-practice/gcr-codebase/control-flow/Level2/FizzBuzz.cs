using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if(n<0) Console.WriteLine("Number is Not Positive");
        else
        {
        
            for(int i = 0; i <= n; i++)
            {
                if(i%3==0 && i%5==0) Console.WriteLine("FizzBuzz");
                else if(i%3==0) Console.WriteLine("Fizz");
                else if(i%5==0) Console.WriteLine("Buzz");
                else Console.WriteLine(i);
            }
        }
    }
}