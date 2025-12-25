using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] digits = NumberChecker.GetDigits(n);

        Console.WriteLine("\nDigits:");
        foreach (int d in digits) Console.Write(d + " ");
        Console.WriteLine();

        int sum = NumberChecker.SumDigits(digits);
        int sumSq = NumberChecker.SumSquares(digits);
        bool harshad = NumberChecker.IsHarshad(n, digits);
        int[,] freq = NumberChecker.DigitFrequency(digits);

        Console.WriteLine($"\nSum of digits = {sum}");
        Console.WriteLine($"Sum of squares = {sumSq}");
        Console.WriteLine($"Harshad Number? {harshad}");

        for (int i = 0; i < 10; i++)
        {
            if (freq[i, 1] > 0) Console.WriteLine($"{freq[i, 0]} :  {freq[i, 1]}");
        }
    }
}

class NumberChecker
{
    public static int CountDigits(int n)
    {
        if(n==0) return 1;

        int count = 0;
        while (n > 0)
        {
            count++;
            n /= 10;
        }
        return count;
    }

    public static int[] GetDigits(int n)
    {
        n = Math.Abs(n);
        int count = CountDigits(n);
        int[] digits = new int[count];

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = n % 10;
            n /= 10;
        }
        return digits;
    }

    public static int SumDigits(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits) sum += d;
        return sum;
    }

    public static int SumSquares(int[] digits)
    {
        int sum = 0;
        foreach (int d in digits) sum += (int)Math.Pow(d, 2);
        return sum;
    }

    public static bool IsHarshad(int n, int[] digits)
    {
        int sum = SumDigits(digits);
        return n % sum == 0;
    }

    public static int[,] DigitFrequency(int[] digits)
    {
        int[,] freq = new int[10, 2];

        for (int i = 0; i < 10; i++) freq[i, 0] = i;

        foreach (int d in digits) freq[d, 1]++;

        return freq;
    }
}


