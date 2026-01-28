using System;
using System.Reflection;

class MathOp
{
    public int Add(int a, int b) { return a + b; }
    public int Sub(int a, int b) { return a - b; }
}

class Program
{
    static void Main()
    {
        MathOp m = new MathOp();

        Console.Write("Enter method name (Add/Sub): ");
        string name = Console.ReadLine();

        MethodInfo method = typeof(MathOp).GetMethod(name);
        object result = method.Invoke(m, new object[] { 10, 5 });

        Console.WriteLine(result);
    }
}
