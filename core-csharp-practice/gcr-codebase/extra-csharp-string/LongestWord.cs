using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.Write("Enter String: ");
        string[] s = Console.ReadLine().Split(" ");

        string ans = "";
        foreach(string x in s)
        {
            if(x.Length>ans.Length) ans = x;
        }

        Console.WriteLine($"Longest Word : {ans}");


    }
}