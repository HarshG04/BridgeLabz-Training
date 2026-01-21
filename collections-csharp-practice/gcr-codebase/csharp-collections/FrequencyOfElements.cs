using System;
using System.Collections.Generic;

class Program
{

    static void Main()
    {
        List<string> list = new List<string> { "apple", "banana", "apple", "orange" };

        CountFreq(list);
    }

    public static void CountFreq(List<string> items)
    {
        Dictionary<string, int> freq = new Dictionary<string, int>();

        for (int i = 0; i < items.Count; i++)
        {
            if (freq.ContainsKey(items[i])) freq[items[i]]++;
            else freq[items[i]] = 1;
        }

        foreach(string key in freq.Keys)
        {
            Console.WriteLine(key + ": " + freq[key]);
        }
    }
}
