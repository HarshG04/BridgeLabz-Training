using System;


class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] digits = NumberChecker.GetDigits(n);
        int[] reversed = NumberChecker.ReverseArray(digits);

        Console.Write("Digits:");
        foreach (int d in digits) Console.Write(d + " ");

        Console.Write("\nReversed:");
        foreach (int d in reversed) Console.Write(d + " ");

        Console.WriteLine("\nPalindrome? " + NumberChecker.IsPalindrome(n));
        Console.WriteLine("Duck Number? " + NumberChecker.IsDuckNumber(n));
    }
}


class NumberChecker
{
    // a) count digits
    public static int CountDigits(int n)
    {
        if (n == 0) return 1;

        n = Math.Abs(n);
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

    // b) reverse digits array
    public static int[] ReverseArray(int[] arr)
    {
        int n = arr.Length;
        int[] rev = new int[n];

        for (int i = 0; i < n; i++)
            rev[i] = arr[n - 1 - i];

        return rev;
    }

    // c) compare two arrays
    public static bool AreArraysEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;

        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i])
                return false;

        return true;
    }

    // d) palindrome check (using digits)
    public static bool IsPalindrome(int n)
    {
        int[] digits = GetDigits(n);
        int[] rev = ReverseArray(digits);

        return AreArraysEqual(digits, rev);
    }

    // e) duck number check (contains a 0, not in leading position)
    public static bool IsDuckNumber(int n)
    {
        n = Math.Abs(n);
        int[] digits = GetDigits(n);

        for (int i = 1; i < digits.Length; i++)
            if (digits[i] == 0)
                return true;

        return false;
    }
}

