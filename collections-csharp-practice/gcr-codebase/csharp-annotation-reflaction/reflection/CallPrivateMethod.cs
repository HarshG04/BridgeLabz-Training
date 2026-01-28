using System;
using System.Reflection;

class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        Calculator c = new Calculator();

        MethodInfo m = typeof(Calculator).GetMethod("Multiply",
            BindingFlags.NonPublic | BindingFlags.Instance);

        object result = m.Invoke(c, new object[] { 3, 4 });

        Console.WriteLine(result);
    }
}
