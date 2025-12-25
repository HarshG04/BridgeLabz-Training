using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] factors = NumberChecker.GetFactors(n);

        Console.WriteLine("\nFactors:");
        foreach (int f in factors)
            Console.Write(f + " ");
        Console.WriteLine();

        Console.WriteLine($"\nGreatest Factor = {NumberChecker.GreatestFactor(factors)}");
        Console.WriteLine($"Sum of Factors = {NumberChecker.SumFactors(factors)}");
        Console.WriteLine($"Product of Factors = {NumberChecker.ProductFactors(factors)}");
        Console.WriteLine($"Product of Cubes of Factors = {NumberChecker.ProductCubeFactors(factors)}");

        Console.WriteLine($"\nPerfect Number?   {NumberChecker.IsPerfect(n)}");
        Console.WriteLine($"Abundant Number?  {NumberChecker.IsAbundant(n)}");
        Console.WriteLine($"Deficient Number? {NumberChecker.IsDeficient(n)}");
        Console.WriteLine($"Strong Number?    {NumberChecker.IsStrong(n)}");
    }
}


class NumberChecker
{
    public static int[] GetFactors(int n)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0) count++;

        int[] fact = new int[count];

        int idx = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0) fact[idx++] = i;

        return fact;
    }

    public static int GreatestFactor(int[] fact)
    {
        if (fact.Length < 2)
            return fact[0];

        return fact[fact.Length - 2];
    }


    public static int SumFactors(int[] fact)
    {
        int sum = 0;
        foreach (int i in fact) sum += i;
        return sum;
    }

    public static long ProductFactors(int[] fact)
    {
        long prod = 1;
        foreach (int i in fact) prod *= i;
        return prod;
    }

    public static double ProductCubeFactors(int[] fact)
    {
        double prod = 1;
        foreach (int i in fact) prod *= Math.Pow(i, 3);
        return prod;
    }

    public static int SumProperDivisors(int n)
    {
        int[] factors = GetFactors(n);
        int sum = 0;

        foreach (int f in factors)
            if (f != n)
                sum += f;

        return sum;
    }

    public static bool IsPerfect(int n)
    {
        return SumProperDivisors(n) == n;
    }

    public static bool IsAbundant(int n)
    {
        return SumProperDivisors(n) > n;
    }

    public static bool IsDeficient(int n)
    {
        return SumProperDivisors(n) < n;
    }

 
    public static bool IsStrong(int n)
    {
        int temp = n;
        int sum = 0;

        while (n > 0)
        {
            int d = n % 10;
            sum += Factorial(d);
            n /= 10;
        }

        return sum == temp;
    }

    private static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;
    }
}

