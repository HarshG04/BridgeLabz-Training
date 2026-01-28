using System;
using System.Reflection;
using System.Text;

class JsonHelper
{
    public static string ToJson(object obj)
    {
        Type t = obj.GetType();
        StringBuilder sb = new StringBuilder("{ ");

        foreach (FieldInfo f in t.GetFields())
        {
            sb.Append($"\"{f.Name}\": \"{f.GetValue(obj)}\", ");
        }

        return sb.ToString().TrimEnd(',', ' ') + " }";
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student { Name = "Harsh", Age = 21 };
        Console.WriteLine(JsonHelper.ToJson(s));
    }
}
