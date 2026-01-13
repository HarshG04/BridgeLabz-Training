using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1,3,4,5};
        int target = 3;

        int missing = FindFirstMissingPositive(arr);
        Console.WriteLine("First Missing Positive: " + missing);

        int index = BinarySearch(arr, target);

        if (index == -1)
            Console.WriteLine("Target not found");
        else
            Console.WriteLine("Target found at index: " + index);
    }

    public static int FindFirstMissingPositive(int[] arr)
    {
        bool[] visited = new bool[arr.Length + 1];

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0 && arr[i] <= arr.Length)
            {
                visited[arr[i]] = true;
            }
        }

        for (int i = 1; i <= arr.Length; i++)
        {
            if (!visited[i])
            {
                return i;
            }
        }

        return arr.Length + 1;
    }

    // Binary Search
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
