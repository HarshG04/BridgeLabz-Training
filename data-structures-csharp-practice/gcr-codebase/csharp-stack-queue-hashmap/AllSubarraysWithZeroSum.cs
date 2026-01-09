using System;
using System.Collections.Generic;

class ZeroSumSubarrays
{
    public static void FindZeroSumSubarrays(int[] arr)
    {
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        int sum = 0;
        bool found = false;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];

            // Case 1: Sum is zero from index 0 to i
            if (sum == 0)
            {
                Console.WriteLine($"Subarray found from index 0 to {i}");
                found = true;
            }

            // Case 2: Sum already exists
            if (map.ContainsKey(sum))
            {
                foreach (int startIndex in map[sum])
                {
                    Console.WriteLine($"Subarray found from index {startIndex + 1} to {i}");
                    found = true;
                }
            }

            // Store the index for current sum
            if (!map.ContainsKey(sum))
                map[sum] = new List<int>();

            map[sum].Add(i);
        }

        if (!found)
            Console.WriteLine("No zero-sum subarray found.");
    }

    static void Main()
    {
        int[] arr = { 3, 4, -7, 3, 1, 3, -4, -2, -2 };

        FindZeroSumSubarrays(arr);
    }
}
