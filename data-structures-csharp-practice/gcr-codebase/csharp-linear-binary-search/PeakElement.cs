using System;

class Program
{
    static void Main()
    {
        int[] arr = { 1, 3, 20, 4, 1, 0 };

        int peakIndex = FindPeak(arr);

        Console.WriteLine("Peak Element: " + arr[peakIndex]);
        Console.WriteLine("Peak Index: " + peakIndex);
    }

    static int FindPeak(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            bool isLeft = (mid == 0) || (arr[mid] > arr[mid - 1]);
            bool isRight = (mid == arr.Length - 1) || (arr[mid] > arr[mid + 1]);

            if (isLeft && isRight)
            {
                return mid;
            }
            else if (mid > 0 && arr[mid - 1] > arr[mid])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return -1;
    }
}
