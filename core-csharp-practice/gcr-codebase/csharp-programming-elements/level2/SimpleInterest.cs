using System;

class SimpleInterest
{
    static void Main()
    {
        Console.Write("Enter principal: ");
        double principal = double.Parse(Console.ReadLine());

        Console.Write("Enter rate of interest: ");
        double rate = double.Parse(Console.ReadLine());

        Console.Write("Enter time: ");
        double time = double.Parse(Console.ReadLine());

        double simpleInterest = (principal * rate * time) / 100;

        Console.WriteLine("The Simple Interest is " + simpleInterest +" for Principal " + principal +", Rate of Interest " + rate +" and Time " + time);
    }
}
