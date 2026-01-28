using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Field)]
class InjectAttribute : Attribute { }

class Engine { }

class Car
{
    [Inject]
    public Engine engine;
}

class Container
{
    public static T Resolve<T>()
    {
        T obj = Activator.CreateInstance<T>();

        foreach (FieldInfo f in typeof(T).GetFields())
        {
            if (f.GetCustomAttribute<InjectAttribute>() != null)
            {
                object dep = Activator.CreateInstance(f.FieldType);
                f.SetValue(obj, dep);
            }
        }
        return obj;
    }
}

class Program
{
    static void Main()
    {
        Car c = Container.Resolve<Car>();
        Console.WriteLine(c.engine != null ? "Engine Injected!" : "Failed");
    }
}
