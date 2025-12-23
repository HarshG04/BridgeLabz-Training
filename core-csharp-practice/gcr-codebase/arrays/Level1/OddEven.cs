using System;

class Program
{
    static void Main()
    {
        
        Console.Write("Enter a num: ");

        int n = Convert.ToInt32(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("number is not a natural number");
            Environment.Exit(0);
        }
        
        int[] even = new int[(n/2)+1];
        int[] odd = new int[(n/2)+1];

        int e = 0 , o = 0;
        for(int i = 1; i <= n; i++)
        {
            if(i%2==0) even[e++] = i;
            else odd[o++] = i;
        }

        Console.Write("Even Numbers: ");
        for(e=0;e<even.Length;e++) Console.Write($"{even[e]} ");
        Console.Write("\nOdd Numbers: ");
        for(o=0;o<odd.Length;o++) Console.Write($"{odd[o]} ");

    }
}