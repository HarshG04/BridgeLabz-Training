using System;
using System.Reflection;

class Person
{
    private int age = 18;
}

class Program
{
    static void Main()
    {
        Person p = new Person();

        FieldInfo f = typeof(Person).GetField("age",
            BindingFlags.NonPublic | BindingFlags.Instance);

        f.SetValue(p, 25);                 // change value
        Console.WriteLine(f.GetValue(p));  // read value
    }
}
