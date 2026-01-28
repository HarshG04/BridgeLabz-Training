using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class LicenseValidate
    {
        static void Main()
        {
            string[] plates = { "AB1234", "A12345", "ab1234" };

            foreach (string plate in plates)
            {
                if (IsValidPlate(plate))
                {
                    Console.WriteLine($"\"{plate}\" -> Valid");
                }
                else
                {
                    Console.WriteLine($"\"{plate}\" -> Invalid");
                }
            }
        }

        static bool IsValidPlate(string plate)
        {
            string pattern = @"^[A-Z]{2}[0-9]{4}$";
            return Regex.IsMatch(plate, pattern);
        }
    }
}
