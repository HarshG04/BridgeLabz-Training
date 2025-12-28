using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        Console.Write("Enter character to remove: ");
        char ch = Console.ReadLine()[0];

        string result = "";

        foreach (char c in s)
            if (c != ch) result += c;

        Console.WriteLine("Modified String: " + result);
    }
}
