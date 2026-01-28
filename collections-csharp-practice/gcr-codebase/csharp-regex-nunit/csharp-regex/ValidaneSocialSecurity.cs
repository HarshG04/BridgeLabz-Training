using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ValidaneSocialSecurity
    {
        static void Main()
        {
            string text = "My SSN is 123-45-6789.";

            string pattern = @"\b\d{3}-\d{2}-\d{4}\b";
            Match match = Regex.Match(text, pattern);

            if (match.Success)
            {
                Console.WriteLine($"\"{match.Value}\" is valid");
            }
            else
            {
                Console.WriteLine("Invalid SSN");
            }

            string invalid = "123456789";
            Console.WriteLine(Regex.IsMatch(invalid, pattern) ? "Valid" : "Invalid");
        }
    }
}
