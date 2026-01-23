using System;
using System.Collections.Generic;
using System.Text;

class NestedTryCatch
{
    static void Main(string[] args)
    {
        try
        {
            int[] numbers = { 10, 20, 30 };

            Console.Write("Enter index: ");
            int index = Convert.ToInt32(Console.ReadLine());

            try
            {
                Console.Write("Enter divisor: ");
                int divisor = Convert.ToInt32(Console.ReadLine());

                int result = numbers[index] / divisor;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid array index!");
        }
    }
}

