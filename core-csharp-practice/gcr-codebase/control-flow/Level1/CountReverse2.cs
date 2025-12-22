using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for(int i=n;i>0;i--)
        {
            Console.WriteLine(i);
        }
        
    }
}