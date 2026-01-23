using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

class HandlingMultipleExceptions
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("1. Null Array");
            Console.WriteLine("2. Invalid Index");
            Console.WriteLine("3. Valid Index");
            Console.Write("Choose option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            int[] nums = null;

            if (choice == 1)
            {
                Console.WriteLine(nums[0]);
            }
            else if (choice == 2)
            {
                nums = new int[] { 10, 20, 30 };
                Console.WriteLine(nums[5]);
            }
            else if (choice == 3)
            {
                nums = new int[] { 10, 20, 30 };
                Console.WriteLine($"Value at index {2}: {nums[2]}");
            }
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
    }
}

