using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the main string: ");
        string s = Console.ReadLine();

        Console.Write("Enter the substring: ");
        string sub = Console.ReadLine();

        int count = 0, idx = 0;

        while ((idx = s.IndexOf(sub, idx)) != -1)
        {
            count++;
            idx += sub.Length;
        }

        Console.WriteLine("Occurrences: " + count);
    }
}
