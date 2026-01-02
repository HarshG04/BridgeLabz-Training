class Book
{
    string title;
    string auther;
    string availability;
    double price;

    Book(string auther,string title,double price)
    {
      this.auther = auther;  
      this.title = title;  
      this.price = price;  
      this.availability = "available";
    }

    void BorrowBook()
    {
        if(this.availability!="available")
        {
            Console.WriteLine("Book not available");
            return;
        }
        Console.WriteLine("Enjoy Your Book");
        this.availability = "not available";
    }

    static void Main()
    {
        Book b1 = new Book("linus","Intro to linux",500.25);
        b1.BorrowBook();
    }
}