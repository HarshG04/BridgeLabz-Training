using System;

class Program
{
    static void Main()
    {
         Console.Write("Enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int temp = n;
        int count = 0;

        while (temp > 0)
        {
            count++;
            temp /= 10;
        }

        int[] digits = new int[count];
        temp = Math.Abs(n);

        for (int i = 0; i < count; i++)
        {
            digits[i] = temp % 10;
            temp /= 10;
        }

        int[] freq = new int[10];

        for (int i = 0; i < count; i++) freq[digits[i]]++;

        for (int i = 0; i < 10; i++)
        {
            if (freq[i] > 0) Console.WriteLine($"{i} : {freq[i]}");
        }
    }
}
