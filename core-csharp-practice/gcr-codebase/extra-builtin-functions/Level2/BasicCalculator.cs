using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Choose Operation:");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");

        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1: Console.WriteLine("Result = " + Add(a, b)); break;
            case 2: Console.WriteLine("Result = " + Subtract(a, b)); break;
            case 3: Console.WriteLine("Result = " + Multiply(a, b)); break;
            case 4: Console.WriteLine("Result = " + Divide(a, b)); break;
            default: Console.WriteLine("Invalid operation"); break;
        }
    }

    static double Add(double x, double y) => x + y;
    static double Subtract(double x, double y) => x - y;
    static double Multiply(double x, double y) => x * y;

    static double Divide(double x, double y)
    {
        if (y == 0)
        {
            Console.WriteLine("Division by zero is not allowed!");
            return double.NaN;
        }
        return x / y;
    }
}
