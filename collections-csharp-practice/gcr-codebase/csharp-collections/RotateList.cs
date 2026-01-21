using System;
using System.Collections.Generic;

class RotateList
{
    public static void Rotate(List<int> list, int k)
    {
        int n = list.Count;
        k = k % n;

        // reverse list
        int i=0, j=list.Count-1;
        while (i <= j)
        {
            int tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
            i++;j--;
        }

        // reverse the 0,length-k

        i = 0; j = list.Count-k-1;
        while (i <= j)
        {
            int tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
            i++;j--;
        }

        // reverse the length-k, length

        i = list.Count-k; j = list.Count-1;
        while (i <= j)
        {
            int tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
            i++;j--;
        }

    }

    static void Main()
    {
        List<int> nums = new List<int> { 10, 20, 30, 40, 50 };

        Rotate(nums, 2);

        foreach (int n in nums) Console.Write(n + " ");
    }
}
