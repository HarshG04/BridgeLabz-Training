using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class CensorBadWords
    {
        static void Main(string[] args)
        {
            string text = "This is a damn bad example with some stupid words.";

            string pattern = @"\b(damn|stupid)\b";
            string result = Regex.Replace(text, pattern, "****");

            Console.WriteLine(result);
        }
    }
}
