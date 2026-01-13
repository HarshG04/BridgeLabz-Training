using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 2, 2, 2, 3, 4, 5, 5, 5, 6 };
        int target = 5;

        int first = FindFirst(arr, target);
        int last = FindLast(arr, target);

        if (first == -1)
        {
            Console.WriteLine("Element not found");
        }
        else
        {
            Console.WriteLine("First Occurrence Index: " + first);
            Console.WriteLine("Last Occurrence Index: " + last);
        }
    }

    static int FindFirst(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                right = mid - 1; // move left
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    static int FindLast(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (arr[mid] == target)
            {
                result = mid;
                left = mid + 1; // move right
            }
            else if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}
