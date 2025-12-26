using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Two Strings: ");
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();

        bool isEqual = Compare(s1,s2);
        bool isEqual1 = s1.Equals(s2);

        Console.WriteLine($"Is Equal Using Method: {isEqual}\nIs Equal Using InBuilt Method: {isEqual1}");

    }

    static bool Compare(string s1,string s2)
    {
        if(s1.Length != s2.Length) return false;
        for(int i = 0; i < s1.Length; i++)
        {
            if(s1[i]!=s2[i]) return false;
        }
        return true;
    }
}