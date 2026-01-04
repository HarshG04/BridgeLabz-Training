using System;

class Book
{
    public static string LibraryName = "Libra Library";

    public static void DisplayLibraryName()
    {
        Console.WriteLine($"Library Name: {LibraryName}");
    }

    public string Title;
    public string Author;
    public readonly string ISBN;

    public Book(string Title, string Author, string ISBN)
    {
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN;
    }


    public void DisplayDetails(object obj)
    {
        if (obj is Book)
        {
            Book b = obj as Book;
            Console.WriteLine("\nBook Details:");
            Console.WriteLine($"Title  : {b.Title}");
            Console.WriteLine($"Author : {b.Author}");
            Console.WriteLine($"ISBN   : {b.ISBN}");
        }
        else
        {
            Console.WriteLine("Object is not a Book.");
        }
    }
}

class Program
{
    static void Main()
    {
        Book.DisplayLibraryName();

        Book book1 = new Book("learn code", "harsh", "ISBN-12345");

        book1.DisplayDetails(book1);
        book1.DisplayDetails("Hello");
    }
}
