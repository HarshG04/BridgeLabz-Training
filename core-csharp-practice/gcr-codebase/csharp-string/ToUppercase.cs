using System;
using System.Text;
class Program
{
    static void Main()
    {
        string s = "haRsh45";
        string upr = ToUpperCase(s);
        string upr1 = s.ToUpper();
        Console.WriteLine($"{upr} and {upr1}");

    }

    static string ToUpperCase(string s)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i]>=97 && s[i]<=122)sb.Append((char)(s[i]-32));
            else sb.Append(s[i]);
        }
        return sb.ToString();
    }
}