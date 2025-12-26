using System;
using System.Text;
class Program
{
    static void Main()
    {
        string s = "HArSH45";
        string upr = ToLowerCase(s);
        string upr1 = s.ToLower();
        Console.WriteLine($"{upr} and {upr1}");

    }

    static string ToLowerCase(string s)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i]>=65 && s[i]<=90)sb.Append((char)(s[i]+32));
            else sb.Append(s[i]);
        }
        return sb.ToString();
    }
}