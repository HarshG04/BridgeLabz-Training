class Book
{
    public string ISBN;
    protected string title;
    private string author;

    public Book(string isbn, string title, string author)
    {
        this.ISBN = isbn;
        this.title = title;
        this.author = author;
    }

    public string GetAuthor()
    {
        return author;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public void ShowBook()
    {
        Console.WriteLine(ISBN);
        Console.WriteLine(title);
        Console.WriteLine(author);
    }
}


class Program
{
    static void Main()
    {
        Book b = new Book("ISBN123", "C# Basics", "harsh");
        b.ShowBook();
        b.SetAuthor("aditya");
        Console.WriteLine(b.GetAuthor());
    }
}