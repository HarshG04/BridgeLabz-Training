using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] digits = NumberChecker.GetDigits(n);

        Console.WriteLine("\nDigits:");
        foreach (int d in digits)
            Console.Write(d + " ");
        Console.WriteLine();

        Console.WriteLine($"Duck Number? {NumberChecker.IsDuckNumber(digits)}");
        Console.WriteLine($"Armstrong Number? {NumberChecker.IsArmstrong(digits)}");

        int[] largest = NumberChecker.FindTwoLargest(digits);
        Console.WriteLine($"Largest digit = {largest[0]}");
        Console.WriteLine($"Second Largest digit = {largest[1]}");

        int[] smallest = NumberChecker.FindTwoSmallest(digits);
        Console.WriteLine($"Smallest digit = {smallest[0]}");
        Console.WriteLine($"Second Smallest digit = {smallest[1]}");
    }
}



class NumberChecker
{
    public static int CountDigits(int n)
    {
        if (n == 0) return 1;
        
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
        int count = CountDigits(n);
        int[] digits = new int[count];

        for (int i = count - 1; i >= 0; i--)
        {
            digits[i] = n % 10;
            n /= 10;
        }
        return digits;
    }

    public static bool IsDuckNumber(int[] digits)
    {
        for (int i = 1; i < digits.Length; i++)
            if (digits[i] == 0)
                return true;

        return false;
    }

    public static bool IsArmstrong(int[] digits)
    {
        int power = digits.Length;
        int sum = 0;

        foreach (int d in digits) sum += (int)Math.Pow(d, power);

        int temp = 0;
        foreach (int d in digits)
            temp = temp * 10 + d;

        return sum == temp;
    }

     public static int[] FindTwoLargest(int[] digits)
    {
        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        foreach (int d in digits)
        {
            if (d > largest)
            {
                secondLargest = largest;
                largest = d;
            }
            else if (d > secondLargest && d != largest)
            {
                secondLargest = d;
            }
        }
        return [largest, secondLargest ];
    }

    public static int[] FindTwoSmallest(int[] digits)
    {
        int smallest = int.MaxValue;
        int secondSmallest = int.MaxValue;

        foreach (int d in digits)
        {
            if (d < smallest)
            {
                secondSmallest = smallest;
                smallest = d;
            }
            else if (d < secondSmallest && d != smallest)
            {
                secondSmallest = d;
            }
        }
        return  [smallest, secondSmallest];
    }
}

