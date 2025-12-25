using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"\nPrime Number? : {NumberChecker.IsPrime(n)}");
        Console.WriteLine($"Neon Number?: {NumberChecker.IsNeon(n)}");
        Console.WriteLine($"Spy Number?: {NumberChecker.IsSpy(n)}");
        Console.WriteLine($"Automorphic Number?: {NumberChecker.IsAutomorphic(n)}");
        Console.WriteLine($"Buzz Number?: {NumberChecker.IsBuzz(n)}");
    }
}
class NumberChecker
{
    public static bool IsPrime(int n)
    {
        for (int i = 2; i < n; i++)
            if (n % i == 0) return false;

        return true;
    }

    public static bool IsNeon(int n)
    {
        int square = n * n;
        int sum = 0;

        while (square > 0)
        {
            sum += square % 10;
            square /= 10;
        }

        return sum == n;
    }

    public static bool IsSpy(int n)
    {
        int sum = 0;
        int product = 1;

        while (n > 0)
        {
            int d = n % 10;
            sum += d;
            product *= d;
            n /= 10;
        }

        return sum == product;
    }

    public static bool IsAutomorphic(int n)
    {
        int square = n * n;
        int temp = n;

        while (temp > 0)
        {
            if (temp % 10 != square % 10) return false;

            temp /= 10;
            square /= 10;
        }

        return true;
    }

    public static bool IsBuzz(int n)
    {
        return (n % 7 == 0) || (n % 10 == 7);
    }
}


