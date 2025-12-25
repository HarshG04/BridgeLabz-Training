using System;

class Program
{
    static void Main()
    {
        int size = 5;

        int[] numbers = Generate4DigitRandomArray(size);
        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine("Generated 4-digit numbers:");
        foreach (int n in numbers) Console.WriteLine(n);

        Console.WriteLine($"\nAverage : {result[0]:F2}");
        Console.WriteLine($"Minimum : {result[1]}");
        Console.WriteLine($"Maximum : {result[2]}");
    }

    static int[] Generate4DigitRandomArray(int size)
    {
        int[] arr = new int[size];
        Random random = new Random();

        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next(1000, 10000);
        }

        return arr;
    }

    static double[] FindAverageMinMax(int[] numbers)
    {
        int min = numbers[0];
        int max = numbers[0];
        int sum = 0;

        foreach (int n in numbers)
        {
            sum += n;
            min = Math.Min(min, n);
            max = Math.Max(max, n);
        }

        double average = (double)sum / numbers.Length;

        return [average, min, max ];
    }
}
