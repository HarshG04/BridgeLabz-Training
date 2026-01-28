using System;

class AuthorAttribute : Attribute
{
    public string Name;
    public AuthorAttribute(string name) { Name = name; }
}

[Author("Harsh")]
class Book { }

class Program
{
    static void Main()
    {
        var attr = (AuthorAttribute)Attribute.GetCustomAttribute(
            typeof(Book), typeof(AuthorAttribute));

        Console.WriteLine(attr.Name);
    }
}
