using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class HexColorValidate
    {
        static void Main(string[] args)
        {
            string[] colors = { "#FFA500", "#ff4500", "#123" };

            foreach (string color in colors)
            {
                if (IsValidHexColor(color))
                {
                    Console.WriteLine($"\"{color}\" -> Valid");
                }
                else
                {
                    Console.WriteLine($"\"{color}\" -> Invalid");
                }
            }
        }

        static bool IsValidHexColor(string color)
        {
            string pattern = @"^#[0-9A-Fa-f]{6}$";
            return Regex.IsMatch(color, pattern);
        }
    }
}
