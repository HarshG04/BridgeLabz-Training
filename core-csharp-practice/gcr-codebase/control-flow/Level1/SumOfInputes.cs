using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter a num: ");
        double num = Convert.ToDouble(Console.ReadLine());
        double sum = 0.0;
        while (num != 0)
        {
            sum += num;
            Console.Write("Enter a num: ");
            num =  Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine(sum);
        
        
    }
}