using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter a Number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] fact = Findfactors(n);
        long[] sumAndProd = SumAndProduct(fact);

        Console.Write("Factors: ");
        for(int i = 0; i < fact.Length; i++)
        {
            if(fact[i]==0) break;
            Console.Write(fact[i]+" ");
        }

        Console.WriteLine($"\nSum of Factors : {sumAndProd[0]}\nSum of Square of Factors : {sumAndProd[1]}\nProduct of factors: {sumAndProd[2]}");

    }

    static int[] Findfactors(int n)
    {
        int[] fact = new int[30];
        int idx = 0;
        for(int i = 1; i <= n; i++)
        {
            if(n%i==0) fact[idx++] = i;
        }

        return fact;
    }

    static long[] SumAndProduct(int[] fact)
    {
        long sum = 0;
        long sumOfSquares = 0;
        long prod = 1;

        foreach(int i in fact)
        {
           if(i==0) break;
           sumOfSquares += (long)Math.Pow(i,2);
           sum += i;
           prod *= i; 
        }

        return [sum,sumOfSquares,prod];
    }
}