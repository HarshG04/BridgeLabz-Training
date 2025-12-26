using System;
class Program
{
    static void Main()
    {
        try
        {
            int[] arr = {10,20,30};
            int num = arr[5];
            Console.WriteLine(num);
        }
        catch(Exception err)
        {
            Console.WriteLine($"{err.GetType()} occures");
        }
    }
}