using System;
class Program
{
    static void Main()
    {
        try
        {
            string s="harsh";   
            char ch = s[10];
        }
        catch(Exception err)
        {
            Console.WriteLine($"{err.GetType().FullName} occures");
        }
    }
}