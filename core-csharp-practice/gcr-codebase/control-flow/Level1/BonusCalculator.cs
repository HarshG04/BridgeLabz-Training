using System;
class Program
{
    static void Main()
    {   
        Console.Write("Enter salary and yos: ");
        int salary = Convert.ToInt32(Console.ReadLine());
        int yos = Convert.ToInt32(Console.ReadLine());
        if (yos > 5)
        {
            double bonus = salary * 0.05;
            Console.WriteLine("Bonus Amount: "+bonus);
        }
    }
}