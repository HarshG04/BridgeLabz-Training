using System;
using System.Reflection;

class MyClass
{
    public int number = 10;
    private string text = "Hello";

    public MyClass() { }
    private MyClass(int x) { number = x; }

    public void Show()
    {
        Console.WriteLine("Public Show Method");
    }

    private void Secret()
    {
        Console.WriteLine("Private Secret Method");
    }
}

class Program
{
    static void Main()
    {
        Type t = typeof(MyClass);

        Console.WriteLine("Methods:");
        foreach (MethodInfo m in t.GetMethods(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine(m.Name);
        }

        Console.WriteLine("\nFields:");
        foreach (FieldInfo f in t.GetFields(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine(f.Name);
        }

        Console.WriteLine("\nConstructors:");
        foreach (ConstructorInfo c in t.GetConstructors(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine(c);
        }

        Console.WriteLine("\n--- Access Private Field ---");
        MyClass obj = new MyClass();
        FieldInfo privateField = t.GetField("text",
            BindingFlags.NonPublic | BindingFlags.Instance);

        Console.WriteLine("Before: " + privateField.GetValue(obj));
        privateField.SetValue(obj, "Changed!");
        Console.WriteLine("After: " + privateField.GetValue(obj));

        Console.WriteLine("\n--- Invoke Private Method ---");
        MethodInfo privateMethod = t.GetMethod("Secret",
            BindingFlags.NonPublic | BindingFlags.Instance);

        privateMethod.Invoke(obj, null);
    }
}
