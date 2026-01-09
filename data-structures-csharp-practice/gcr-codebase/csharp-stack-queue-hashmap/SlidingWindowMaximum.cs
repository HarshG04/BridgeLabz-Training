using System;
using System.Collections.Generic;

class SlidingWindowMaximum
{
    public static void FindMaxInWindows(int[] arr, int k)
    {
        if (arr.Length == 0 || k <= 0)
            return;

        LinkedList<int> deque = new LinkedList<int>(); // stores indices

        for (int i = 0; i < arr.Length; i++)
        {
            // 1. Remove indices outside the window
            if (deque.Count > 0 && deque.First.Value <= i - k)
                deque.RemoveFirst();

            // 2. Remove smaller elements from the back
            while (deque.Count > 0 && arr[deque.Last.Value] <= arr[i])
                deque.RemoveLast();

            // 3. Add current index
            deque.AddLast(i);

            // 4. Print max when window is formed
            if (i >= k - 1)
                Console.Write(arr[deque.First.Value] + " ");
        }
    }

    static void Main()
    {
        int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int k = 3;

        Console.WriteLine("Sliding Window Maximums:");
        FindMaxInWindows(arr, k);
    }
}
