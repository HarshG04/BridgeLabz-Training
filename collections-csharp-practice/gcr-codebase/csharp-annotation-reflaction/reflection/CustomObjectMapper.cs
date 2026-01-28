using System;
using System.Collections.Generic;
using System.Reflection;

class Student
{
    public string Name;
    public int Age;
}

class Mapper
{
    public static T ToObject<T>(Type type, Dictionary<string, object> props)
    {
        T obj = (T)Activator.CreateInstance(type);

        foreach (KeyValuePair<string, object> item in props)
        {
            FieldInfo field = type.GetField(item.Key);
            if (field != null)
                field.SetValue(obj, item.Value);
        }

        return obj;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, object> data = new Dictionary<string, object>()
        {
            {"Name","Harsh"},
            {"Age",21}
        };

        Student s = Mapper.ToObject<Student>(typeof(Student), data);
        Console.WriteLine(s.Name + " " + s.Age);
    }
}
