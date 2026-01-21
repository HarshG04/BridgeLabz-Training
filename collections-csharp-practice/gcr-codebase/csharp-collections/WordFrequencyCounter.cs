using System;
using System.Collections.Generic;

class WordFrequencyCounter
{
    static void Main()
    {
        string text = "Hello world, hello Java!";

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        string[] words = text
            .ToLower()
            .Replace(",", "")
            .Replace("!", "")
            .Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (wordCount.ContainsKey(words[i]))
                wordCount[words[i]]++;
            else
                wordCount[words[i]] = 1;
        }

        foreach (KeyValuePair<string, int> entry in wordCount)
        {
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }
    }
}
