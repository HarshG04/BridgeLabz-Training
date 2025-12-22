using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int count = 0;

        while (num>0)
        {
            num /= 10;
            count++;
        }

        Console.WriteLine(count);
    }
}
