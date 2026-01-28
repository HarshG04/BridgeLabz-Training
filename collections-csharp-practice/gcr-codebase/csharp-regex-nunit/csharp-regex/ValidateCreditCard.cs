using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ValidateCreditCard
    {
        static void Main()
        {
            string visa = "4123456789012345";
            string master = "5123456789012345";
            string invalid = "3123456789012345";

            ValidateCard(visa);
            ValidateCard(master);
            ValidateCard(invalid);
        }

        static void ValidateCard(string cardNumber)
        {
            if (Regex.IsMatch(cardNumber, @"^4\d{15}$"))
            {
                Console.WriteLine($"{cardNumber} -> Valid Visa card");
            }
            else if (Regex.IsMatch(cardNumber, @"^5\d{15}$"))
            {
                Console.WriteLine($"{cardNumber} -> Valid MasterCard");
            }
            else
            {
                Console.WriteLine($"{cardNumber} -> Invalid card");
            }
        }
    }
}
