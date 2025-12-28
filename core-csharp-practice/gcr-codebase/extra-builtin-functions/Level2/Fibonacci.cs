using System;
class Program
{
    static void Main()
    {
        Console.Write("enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());
        Fibonacci(n);
    }
    static void Fibonacci(int n)
    {
        int a = 0;
        int b = 1;
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(a);
            int c = a+b;
            a = b;
            b = c;
        }
    }
}