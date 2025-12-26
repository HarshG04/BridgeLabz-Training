using System;
class Program
{
    static void Main()
    {
        try
        {
            string s=null;   
            int len = s.Length;
        }
        catch(Exception err)
        {
            Console.WriteLine($"{err.GetType().FullName} occures");
        }
    }
}