using System;
using System.Collections.Generic;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class CacheResultAttribute : Attribute { }

class Calculator
{
    [CacheResult]
    public int Square(int n)
    {
        Console.WriteLine("Calculating square...");
        return n * n;
    }
}

class CacheExecutor
{
    private static Dictionary<string, object> cache = new Dictionary<string, object>();

    public static object Execute(object obj, string methodName, object[] parameters)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);
        var attr = method.GetCustomAttribute<CacheResultAttribute>();

        string key = methodName + "_" + string.Join("_", parameters);

        if (attr != null && cache.ContainsKey(key))
        {
            Console.WriteLine("Returning cached result");
            return cache[key];
        }

        object result = method.Invoke(obj, parameters);

        if (attr != null)
            cache[key] = result;

        return result;
    }
}

class Program
{
    static void Main()
    {
        Calculator c = new Calculator();

        Console.WriteLine(CacheExecutor.Execute(c, "Square", new object[] { 4 }));
        Console.WriteLine(CacheExecutor.Execute(c, "Square", new object[] { 4 }));
    }
}
