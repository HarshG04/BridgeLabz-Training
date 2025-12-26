using System;
class Program
{
    static void Main()
    {
        try
        {
            string s="Harsh";   
            string str = s.Substring(5,2);
        }
        catch(Exception err)
        {
            Console.WriteLine($"{err.GetType().FullName} occures");
        }
    }
}