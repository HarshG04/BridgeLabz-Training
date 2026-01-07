using System;
using System.Collections.Generic;

abstract class LibraryItem
{
    private int itemId;
    private string title;
    private string author;

    public int ItemId
    {
        get => itemId;
        set => itemId = value;
    }

    public string Title
    {
        get => title;
        set => title = value ?? string.Empty;
    }

    public string Author
    {
        get => author;
        set => author = value ?? string.Empty;
    }

    internal virtual string GetInternalInfo() => "LibraryItem";

    public LibraryItem(int id, string title, string author)
    {
        ItemId = id;
        Title = title;
        Author = author;
    }

    public void GetItemDetails()
    {
        Console.WriteLine($"ID:{ItemId}, Title:{Title}, Author:{Author}");
    }

    public abstract int GetLoanDuration();
}

interface IReservable
{
    bool ReserveItem(string user);
    bool CheckAvailability();
}

class Book : LibraryItem, IReservable
{
    private bool reserved = false;
    private string reservedBy = string.Empty;

    public Book(int id, string title, string author) : base(id, title, author) { }

    internal override string GetInternalInfo() => "Book";

    public override int GetLoanDuration() => 21; // days

    public bool ReserveItem(string user)
    {
        if (reserved) return false;
        reserved = true; reservedBy = user; return true;
    }

    public bool CheckAvailability() => !reserved;
}

class Magazine : LibraryItem
{
    public Magazine(int id, string title, string author) : base(id, title, author) { }

    internal override string GetInternalInfo() => "Magazine";

    public override int GetLoanDuration() => 7;
}

class DVD : LibraryItem, IReservable
{
    private bool reserved = false;

    public DVD(int id, string title, string author) : base(id, title, author) { }

    internal override string GetInternalInfo() => "DVD";

    public override int GetLoanDuration() => 5;

    public bool ReserveItem(string user)
    {
        if (reserved) return false;
        reserved = true; return true;
    }

    public bool CheckAvailability() => !reserved;
}

class ProgramLibrary
{
    static void Main()
    {
        var items = new List<LibraryItem>
        {
            new Book(1, "Clean Code", "Robert C. Martin"),
            new Magazine(2, "Tech Monthly", "Editor Team"),
            new DVD(3, "Educational DVD", "Producer")
        };

        foreach (var item in items)
        {
            item.GetItemDetails();
            Console.WriteLine($"Type: {item.GetType().Name}, LoanDays: {item.GetLoanDuration()}");
            Console.WriteLine();
        }
    }
}
