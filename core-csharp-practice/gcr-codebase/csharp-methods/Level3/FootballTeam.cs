using System;

class Program
{
    static void Main()
    {
        int[] heights = new int[11];
        Random rnd = new Random();

        for (int i = 0; i < heights.Length; i++)
        {
            heights[i] = rnd.Next(150, 251);
        }

        Console.WriteLine("Heights of players (in cms):");
        foreach (int h in heights) Console.Write(h + " ");

        Console.WriteLine();

        int sum = FindSum(heights);
        double mean = FindMean(heights);
        int shortest = FindShortest(heights);
        int tallest = FindTallest(heights);

        Console.WriteLine($"\nTotal Height Sum = {sum} cms");
        Console.WriteLine($"Mean Height = {mean:F2} cms");
        Console.WriteLine($"Shortest Player Height = {shortest} cms");
        Console.WriteLine($"Tallest Player Height = {tallest} cms");
    }

    static int FindSum(int[] arr)
    {
        int sum = 0;
        foreach (int n in arr) sum += n;
        return sum;
    }

    static double FindMean(int[] arr)
    {
        return (double)FindSum(arr) / arr.Length;
    }

    static int FindShortest(int[] arr)
    {
        int min = arr[0];
        foreach (int n in arr)
            if (n < min) min = n;
        return min;
    }

    static int FindTallest(int[] arr)
    {
        int max = arr[0];
        foreach (int n in arr)
            if (n > max)
                max = n;
        return max;
    }
}
