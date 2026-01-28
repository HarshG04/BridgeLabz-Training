using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ReplaceSpace
    {
        static void Main(string[] args)
        {
            string text = "This is an example with multiple spaces.";
            string result = Regex.Replace(text, @"\s+", " ");
            Console.WriteLine(result);
        }
    }
}
