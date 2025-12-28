using System;
using System.Text;
class Program
{
    static void Main()
    {
        Console.Write("Enter String: ");
        string s = Console.ReadLine();

        StringBuilder sb = new();
        for(int i = 0; i < s.Length; i++)
        {   
            bool flag = true;
            for(int j = 0; j < s.Length; j++)
            {
                if (i!=j && s[i] == s[j])
                {
                    flag = false;
                    break;
                }
            }

            if(flag) sb.Append(s[i]);
        }

        Console.WriteLine($"{sb}");
    }
}