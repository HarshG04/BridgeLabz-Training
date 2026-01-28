using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ExtractCurrrency
    {
        static void Main(string[] args)
        {
            string text = "The price is $45.99, and the discount is $ 10.50.";

            string pattern = @"\$\s?\d+(\.\d{2})?";
            MatchCollection matches = Regex.Matches(text, pattern);

            foreach (Match match in matches)
            {
                string value = match.Value.Replace("$ ", "");
                Console.Write(value + ", ");
            }
        }
    }
}
