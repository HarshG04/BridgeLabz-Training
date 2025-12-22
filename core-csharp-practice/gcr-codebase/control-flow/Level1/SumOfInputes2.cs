using System;
class Program
{
    static void Main()
    {   
        double num = 0.0;
        double sum = 0.0;
        while (true)
        {
            Console.Write("Enter a num: ");
            num =  Convert.ToDouble(Console.ReadLine());
            if(num<=0) break;
            sum += num;
        }

        Console.WriteLine(sum);
        
        
    }
}