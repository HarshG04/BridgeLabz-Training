using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());

        int tmp = num;
        int sum = 0;

        while (tmp != 0)
        {
            int rem = tmp % 10;
            sum += rem * rem * rem;
            tmp /= 10;
        }

        if (sum == num) Console.WriteLine("Armstrong Number");
        else
            Console.WriteLine("Not an Armstrong Number");
    }
}
