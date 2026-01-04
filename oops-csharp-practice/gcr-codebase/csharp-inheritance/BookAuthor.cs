using System;

public class Book
{
    public string title;
    public int publicationYear;
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Title: {title}, PublicationYear: {publicationYear}");
    }
}

public class Author : Book
{
    public string name;
    public string bio;
    public override void DisplayInfo()
    {
        Console.WriteLine($"Title: {title}, PublicationYear: {publicationYear}, Author: {name}, Bio: {bio}");
    }
}

public class Program
{
    public static void Main()
    {
        Author author = new Author { title = "C# Basics", publicationYear = 2025, name = "harsh", bio = "CSE student" };
        author.DisplayInfo();
    }
}
