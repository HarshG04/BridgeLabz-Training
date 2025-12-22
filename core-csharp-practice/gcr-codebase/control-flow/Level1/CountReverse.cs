using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a num: ");
        int n = Convert.ToInt32(Console.ReadLine());
        while (n > 0)
        {
            Console.WriteLine(n--);
        }
        
    }
}