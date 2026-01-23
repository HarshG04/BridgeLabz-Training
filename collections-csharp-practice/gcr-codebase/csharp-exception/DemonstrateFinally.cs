using System;
using System.Collections.Generic;
using System.Text;

class DemonstrateFinally
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter the Numerator : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the Denomination : ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int result = num1 / num2;
            Console.WriteLine($"Result : {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error : Divide By Zero Not Possible");
        }
        finally
        {
            Console.WriteLine("Operation Completed");
        }
    }
}

