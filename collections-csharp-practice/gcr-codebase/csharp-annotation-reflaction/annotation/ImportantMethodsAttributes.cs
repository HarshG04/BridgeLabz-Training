using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
class ImportantMethodAttribute : Attribute
{
    public string Level { get; set; } = "HIGH";

    public ImportantMethodAttribute() { }

    public ImportantMethodAttribute(string level)
    {
        Level = level;
    }
}

class Work
{
    [ImportantMethod]   // default HIGH
    public void SaveData() { }

    [ImportantMethod("CRITICAL")]
    public void DeleteAll() { }

    public void NormalTask() { }
}


class Program
{
    static void Main()
    {
        var methods = typeof(Work).GetMethods();

        foreach (var m in methods)
        {
            var attr = m.GetCustomAttribute<ImportantMethodAttribute>();
            if (attr != null)
                Console.WriteLine($"{m.Name} - Level: {attr.Level}");
        }
    }
}
