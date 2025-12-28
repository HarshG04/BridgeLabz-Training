using System;

class Program
{
    static void Main()
    {   
        Console.Write("Enter a number: ");
        int n =  Convert.ToInt32(Console.ReadLine());
        long fact = Factorial(n);
        DisplayResult(n, fact);
    }


    static long Factorial(int n)
    {
        if (n <= 1)
            return 1;

        return n * Factorial(n - 1);
    }

    static void DisplayResult(int n, long fact)
    {
        Console.WriteLine($"Factorial of {n} = {fact}");
    }
}
