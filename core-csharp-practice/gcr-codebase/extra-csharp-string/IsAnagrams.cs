using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string s1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string s2 = Console.ReadLine();

        if (IsAnagram(s1, s2)) Console.WriteLine("The strings are anagrams.");
        else Console.WriteLine("The strings are NOT anagrams.");
    }

    static bool IsAnagram(string a, string b)
    {
        if (a.Length != b.Length) return false;

        int[] freq = new int[26];

        foreach (char ch in a) freq[ch-97]++;

        foreach (char ch in b) freq[ch-97]--;

        foreach (int f in freq)
            if (f != 0)
                return false;

        return true;
    }
}
