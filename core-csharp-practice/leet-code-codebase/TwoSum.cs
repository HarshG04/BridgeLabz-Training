using System.Collections.Generic;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (map.ContainsKey(target - nums[i]))
                return new int[] { i, map[target - nums[i]] };

            map[nums[i]] = i;
        }

        return new int[0];
    }
}
