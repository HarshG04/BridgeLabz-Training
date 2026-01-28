using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class RepeatingWords
    {
        static void Main(string[] args)
        {
            string text = "This is is a repeated repeated word test.";

            string[] words = Regex.Split(text, @"\W+");

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (words[i].Equals(words[i + 1], StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write(words[i] + ", ");
                }
            }
        }
    }
}
