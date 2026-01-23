using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsAcrossMethods
{
    static void Method1()
    {
        int x = 0;
        int result = 10 / x;
    }

    static void Method2()
    {
        Method1();
    }

    static void Main()
    {
        try
        {
            Method2();
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Handled exception in Main");
        }
    }
}

