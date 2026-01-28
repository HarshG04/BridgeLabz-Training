using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ExtractLinks
    {
        static void Main(string[] args)
        {
            string text = "Visit https://www.google.com and http://example.org for more info";

            string pattern = @"\s+";
            string[] words = Regex.Split(text, pattern);

            foreach (string word in words)
            {
                string clean = word.Trim(',', '.');

                if (Regex.IsMatch(clean, @"^(https?://)?(www\.)?[\w\-]+(\.[\w\-]+)+(/[\w\-./?%&=]*)?$"))
                {
                    Console.Write(clean + ", ");
                }
            }
        }
    }
}
