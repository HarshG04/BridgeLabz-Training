using System;
using System.Reflection;


[AttributeUsage(AttributeTargets.Field)]
class MaxLengthAttribute : Attribute
{
    public int Value;
    public MaxLengthAttribute(int value) => Value = value;
}


class User
{
    [MaxLength(10)]
    public string Username;

    public User(string username)
    {
        FieldInfo f = typeof(User).GetField("Username");
        var attr = f.GetCustomAttribute<MaxLengthAttribute>();

        if (attr != null && username.Length > attr.Value)
            throw new ArgumentException("Username too long!");

        Username = username;
    }
}

class Program
{
    static void Main()
    {
        User u1 = new User("Harsh");
        User u2 = new User("Harshhhhhhhhhhhhhhhhh"); 
    }
}

