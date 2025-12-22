using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double first = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double second = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter operator (+, -, *, /): ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "+": Console.WriteLine(first + second);
                break;
            case "-":   Console.WriteLine(first - second);
                break;
            case "*":   Console.WriteLine(first * second);
                break;
            case "/":
                    if (second != 0) Console.WriteLine(first / second);
                    else Console.WriteLine("Division by zero not allowed");
                break;
            default: Console.WriteLine("Invalid Operator");
                break;
        }
    }
}
