using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ExtractEmail
    {
        static void Main(string[] args)
        {
            string text = "Contact us at support@example.com and info@company.org";

            string pattern = @"\s+";
            string[] words = Regex.Split(text, pattern);

            foreach (string word in words)
            {
                if (Regex.IsMatch(word,
                    @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$"))
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
