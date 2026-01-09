using System;
using System.Collections.Generic;

class TwoSum
{
    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;

        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int need = target - nums[i];

            if (map.ContainsKey(need))
            {
                Console.WriteLine($"Indices: {map[need]}, {i}");
                return;
            }

            map[nums[i]] = i;
        }

        Console.WriteLine("No pair found");
    }
}
