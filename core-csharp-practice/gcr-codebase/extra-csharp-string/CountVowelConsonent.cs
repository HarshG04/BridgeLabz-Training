using System;
class Program{
    static void Main()
    {
        Console.Write("Enter String: ");
        string s = Console.ReadLine();
        string v = "aeiou";
        int vowel = 0, consonent = 0;
        foreach(char ch in s)
        {   
            if(ch==' ') continue;
            if(v.Contains(ch)) vowel++;
            else consonent++;
        }
        Console.WriteLine($"Vowels:{vowel}  Consonent:{consonent}");
    }
}