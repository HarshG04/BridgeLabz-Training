using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.Write("Enter String: ");
        string s = Console.ReadLine();
        StringBuilder sb = new();
        for(int i=s.Length-1;i>=0;i--) sb.Append(s[i]);

        string rev = sb.ToString();
        Console.WriteLine($"Reverse String : {rev}");        
    }
}