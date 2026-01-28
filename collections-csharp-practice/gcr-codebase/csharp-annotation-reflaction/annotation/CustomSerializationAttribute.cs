using System;
using System.Reflection;
using System.Text;

[AttributeUsage(AttributeTargets.Field)]
class JsonFieldAttribute : Attribute
{
    public string Name { get; set; }
    public JsonFieldAttribute(string name)
    {
        Name = name;
    }
}

class User
{
    [JsonField("user_name")]
    public string Username;

    [JsonField("user_age")]
    public int Age;

    public string Password;
}

class JsonSerializer
{
    public static string ToJson(object obj)
    {
        Type t = obj.GetType();
        StringBuilder sb = new StringBuilder("{ ");

        foreach (FieldInfo f in t.GetFields())
        {
            var attr = f.GetCustomAttribute<JsonFieldAttribute>();
            if (attr != null)
            {
                string key = attr.Name;
                object value = f.GetValue(obj);
                sb.Append($"\"{key}\": \"{value}\", ");
            }
        }

        return sb.ToString().TrimEnd(',', ' ') + " }";
    }
}

class Program
{
    static void Main()
    {
        User u = new User
        {
            Username = "Harsh",
            Age = 21,
            Password = "secret"
        };

        Console.WriteLine(JsonSerializer.ToJson(u));
    }
}
