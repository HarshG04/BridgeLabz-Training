using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ExtractProgrammingLanguageName
    {
        static void Main(string[] args)
        {
            string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";
            string[] words = Regex.Split(text, @"\W+");

            foreach (string word in words)
            {
                if (Regex.IsMatch(word, @"^(Java|Python|JavaScript|Go)$"))
                {
                    Console.Write(word + ", ");
                }
            }
        }
    }
}
