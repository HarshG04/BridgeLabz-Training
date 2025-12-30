class Book
{
    private string title;
    private string auther;
    private double price;

    public void SetDetails(string title,string auther,double price)
    {
        this.title = title;
        this.auther = auther;
        this.price = price;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Auther Name: {auther}");
        Console.WriteLine($"price: {price}");
    }
}

class Program
{
    static void Main()
    {
        Book b1 = new Book();
        b1.SetDetails("Learn Code","Harsh",250.75);
        b1.ShowDetails();
    }
}