using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string s = Console.ReadLine();

        int[] freq = new int[26];

        foreach (char ch in s) freq[ch-97]++;

        int max = 0;
        char most = ' ';

        for (int i = 0; i < 26; i++)
        {
            if (freq[i] > max)
            {
                max = freq[i];
                most = (char)(i+97);
            }
        }

        Console.WriteLine("Most Frequent Character: '" + most + "'");
    }
}
