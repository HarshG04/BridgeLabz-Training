using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ExtractCapitalWords
    {
        static void Main(string[] args)
        {
            string text = "The Eiffel Tower is in Paris and the Statue of Liberty is in New York.";

            string pattern = @"\s+";
            string[] words = Regex.Split(text, pattern);

            foreach (string word in words)
            {
                string clean = word.Trim('.', ',');
                if (Regex.IsMatch(clean, @"^[A-Z]"))
                {
                    Console.Write(clean + ", ");
                }
            }
        }
    }
}
