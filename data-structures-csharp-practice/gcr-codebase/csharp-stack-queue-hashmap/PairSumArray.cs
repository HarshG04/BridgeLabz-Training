using System;
using System.Collections.Generic;

class PairWithGivenSum
{
    static bool HasPair(int[] arr, int target)
    {
        HashSet<int> seen = new HashSet<int>();

        for (int i = 0; i < arr.Length; i++)
        {
            int required = target - arr[i];

            if (seen.Contains(required))
                return true;

            seen.Add(arr[i]);
        }

        return false;
    }

    static void Main()
    {
        int[] arr = { 8, 4, 1, 6 };
        int target = 10;

        Console.WriteLine(HasPair(arr, target));
    }
}
