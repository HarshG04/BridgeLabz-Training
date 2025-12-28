using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine();

        int len = Math.Min(s1.Length, s2.Length);
        int i = 0;

        while (i < len && s1[i] == s2[i]) i++;

        if (i == len)
        {
            if (s1.Length == s2.Length)
                Console.WriteLine("Both strings are equal");
            else if (s1.Length < s2.Length)
                Console.WriteLine($"\"{s1}\" comes before \"{s2}\"");
            else
                Console.WriteLine($"\"{s2}\" comes before \"{s1}\"");
        }
        else if (s1[i] < s2[i])
            Console.WriteLine($"\"{s1}\" comes before \"{s2}\"");
        else
            Console.WriteLine($"\"{s2}\" comes before \"{s1}\"");
    }
}
