using System;

class Book
{
    public int bookId;
    public string title;
    public string author;
    public string genre;
    public bool isAvailable;

    public Book next;
    public Book prev;

    public Book(int id, string title, string author, string genre, bool isAvailable)
    {
        this.bookId = id;
        this.title = title;
        this.author = author;
        this.genre = genre;
        this.isAvailable = isAvailable;

        this.next = null;
        this.prev = null;
    }
}

class Library
{
    private Book head;
    private Book tail;
    private int count = 0;

    public void AddBook()
    {
        Console.Write("Enter Book ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        Console.Write("Enter Genre: ");
        string genre = Console.ReadLine();

        Console.Write("Is Available? (y/n): ");
        bool available = Console.ReadLine().ToLower() == "y";

        Book newBook = new Book(id, title, author, genre, available);

        if (head == null)
        {
            head = tail = newBook;
        }
        else
        {
            tail.next = newBook;
            newBook.prev = tail;
            tail = newBook;
        }

        count++;
        Console.WriteLine("Book added successfully.");
    }

    public void RemoveBook()
    {
        if (head == null)
        {
            Console.WriteLine("No books available.");
            return;
        }

        Console.Write("Enter Book ID to remove: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Book temp = head;

        while (temp != null && temp.bookId != id)
            temp = temp.next;

        if (temp == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        if (temp == head)
            head = head.next;

        if (temp == tail)
            tail = tail.prev;

        if (temp.prev != null)
            temp.prev.next = temp.next;

        if (temp.next != null)
            temp.next.prev = temp.prev;

        count--;
        Console.WriteLine("Book removed.");
    }

    public void SearchBook()
    {
        Console.WriteLine("Search By: 1 = Title, 2 = Author");
        int op = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value: ");
        string value = Console.ReadLine();

        Book temp = head;
        bool found = false;

        while (temp != null)
        {
            if ((op == 1 && temp.title.Equals(value, StringComparison.OrdinalIgnoreCase)) ||
                (op == 2 && temp.author.Equals(value, StringComparison.OrdinalIgnoreCase)))
            {
                PrintBook(temp);
                found = true;
            }

            temp = temp.next;
        }

        if (!found)
            Console.WriteLine("No matching book found.");
    }

    public void UpdateAvailability()
    {
        Console.Write("Enter Book ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Book temp = head;

        while (temp != null)
        {
            if (temp.bookId == id)
            {
                Console.Write("Is Available? (y/n): ");
                temp.isAvailable = Console.ReadLine().ToLower() == "y";
                Console.WriteLine("Availability updated.");
                return;
            }

            temp = temp.next;
        }

        Console.WriteLine("Book not found.");
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No books.");
            return;
        }

        Console.WriteLine("\n===== LIBRARY BOOKS =====");
        Book temp = head;

        while (temp != null)
        {
            PrintBook(temp);
            temp = temp.next;
        }
    }

    public void CountBooks()
    {
        Console.WriteLine($"\nTotal Books: {count}");
    }

    private void PrintBook(Book b)
    {
        Console.WriteLine($"ID:{b.bookId} | Title:{b.title} | Author:{b.author} | Genre:{b.genre} | Available:{b.isAvailable}");
    }
}

class Program
{
    static void Main()
    {
        Library lib = new Library();

        while (true)
        {
            Console.WriteLine("\n===== LIBRARY MENU =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Remove Book");
            Console.WriteLine("3. Search Book");
            Console.WriteLine("4. Update Availability");
            Console.WriteLine("5. Display All Books");
            Console.WriteLine("6. Count Books");
            Console.WriteLine("7. Exit");
            Console.Write("Enter Choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1: lib.AddBook(); 
                    break;
                case 2: lib.RemoveBook(); 
                    break;
                case 3: lib.SearchBook(); 
                    break;
                case 4: lib.UpdateAvailability(); 
                    break;
                case 5: lib.DisplayAll(); 
                    break;
                case 6: lib.CountBooks(); 
                    break;
                case 7: return; 
                default: Console.WriteLine("Invalid Choice."); 
                    break;
            }
        }
    }
}
