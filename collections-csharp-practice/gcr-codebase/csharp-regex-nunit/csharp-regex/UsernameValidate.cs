using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class UsernameValidate
    {
        static void Main(string[] args)
        {
            string[] usernames = { "user_123", "123user", "us" };

            foreach (string username in usernames)
            {
                if (IsValidUsername(username))
                {
                    Console.WriteLine($"\"{username}\" -> Valid");
                }
                else
                {
                    Console.WriteLine($"\"{username}\" -> Invalid");
                }
            }
        }

        static bool IsValidUsername(string username)
        {
            string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";
            return Regex.IsMatch(username, pattern);
        }
    }
}
