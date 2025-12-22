using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int tmp = num;
        int sum = 0;

        while (num != 0)
        {
            sum += num % 10;
            num /= 10;
        }

        if (tmp % sum == 0) Console.WriteLine("Harshad Number");
        else Console.WriteLine("Not a Harshad Number");
    }
}
