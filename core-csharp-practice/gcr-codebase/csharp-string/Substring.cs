using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter String, si and ei: ");
        string s = Console.ReadLine();
        int si = Convert.ToInt32(Console.ReadLine());
        int ei = Convert.ToInt32(Console.ReadLine());
        

        string subStr = MySubstring(s,si,ei);
        string subStr1 = s.Substring(si,(ei-si+1));

        Console.WriteLine($"SubString Using Method: {subStr}\nSubstring Using InBuilt Method: {subStr1}");

    }

    static string MySubstring(string s,int si,int ei)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = si; i < ei; i++)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }
}