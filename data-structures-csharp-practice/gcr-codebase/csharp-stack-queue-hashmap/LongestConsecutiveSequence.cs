using System;
using System.Collections.Generic;

class LongestConsecutiveSequence
{
    static int LongestSequence(int[] arr)
    {
        HashSet<int> set = new HashSet<int>(arr);
        int longest = 0;

        foreach (int num in set)
        {
            // start only if num is the beginning
            if (!set.Contains(num - 1))
            {
                int currentNum = num;
                int count = 1;

                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    count++;
                }

                longest = Math.Max(longest, count);
            }
        }

        return longest;
    }

    static void Main()
    {
        int[] arr = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine(LongestSequence(arr));
    }
}
