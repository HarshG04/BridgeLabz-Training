using System;
class Program
{
    static void Main()
    {
        try
        {
            string s="harsh";   
            int num = int.Parse(s);
            Console.WriteLine(num);
        }
        catch(Exception err)
        {
            Console.WriteLine($"{err.GetType().FullName} occures");
        }
    }
}