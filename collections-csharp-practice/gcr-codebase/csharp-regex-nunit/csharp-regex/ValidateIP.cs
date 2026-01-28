using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BridgeLabzTraining.collections_csharp_practice.gcr_codebase.csharp_regex_and_nunits.csharp_regex
{
    internal class ValidateIP
    {
        static void Main()
        {
            string[] ips = { "192.168.1.1", "255.255.255.255", "256.10.1.1" };

            string pattern = @"^((25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)\.){3}(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)$";

            foreach (string ip in ips)
            {
                Console.WriteLine($"{ip} -> {Regex.IsMatch(ip, pattern)}");
            }
        }
    }
}
