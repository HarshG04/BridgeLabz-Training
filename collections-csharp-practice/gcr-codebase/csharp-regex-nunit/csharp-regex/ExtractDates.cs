using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ExtractDates
    {
        static void Main(string[] args)
        {
            string text = "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020";

            string pattern = @"\s+";
            string[] words = Regex.Split(text, pattern);

            foreach (string word in words)
            {
                string clean = word.Trim(',', '.');

                if (Regex.IsMatch(clean, @"^\d{2}/\d{2}/\d{4}$"))
                {
                    Console.Write(clean + ", ");
                }
            }
        }
    }
}
