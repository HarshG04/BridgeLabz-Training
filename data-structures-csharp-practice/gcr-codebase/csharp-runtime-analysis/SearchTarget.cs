using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int n = 5000000;
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            arr[i] = i + 1;
        }

        int target = n;

        // Linear Search
        Stopwatch watch1 = new Stopwatch();
        watch1.Start();
        LinearSearch(arr, target);
        watch1.Stop();

        Console.WriteLine($"Linear Search Time in ms:  {watch1.ElapsedMilliseconds}ms");

        // Binary Search
        Stopwatch watch2 = new Stopwatch();
        watch2.Start();
        BinarySearch(arr, target);
        watch1.Stop();

        Console.WriteLine($"Binary Search Time in ms:  {watch2.ElapsedMilliseconds}ms");
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target) return i;
        }
        return -1;
    }

    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == target)
                return mid;
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}
