using System;
using System.Reflection;

class Config
{
    private static string KEY = "OLD";
}

class Program
{
    static void Main()
    {
        FieldInfo f = typeof(Config).GetField("KEY",
            BindingFlags.NonPublic | BindingFlags.Static);

        f.SetValue(null, "NEW_KEY");

        Console.WriteLine(f.GetValue(null));
    }
}
