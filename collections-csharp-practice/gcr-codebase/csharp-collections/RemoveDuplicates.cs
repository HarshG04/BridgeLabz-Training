using System;
using System.Collections.Generic;

class RemoveDuplicates
{

    static void Main()
    {
        List<int> list = new List<int> { 3, 1, 2, 2, 3, 4 };

        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();


        for (int i = 0; i < list.Count; i++)
        {
            if (!seen.Contains(list[i]))
            {
                seen.Add(list[i]);
                result.Add(list[i]);
            }
        }

        foreach (int n in output) Console.Write(n + " ");
    }
}
