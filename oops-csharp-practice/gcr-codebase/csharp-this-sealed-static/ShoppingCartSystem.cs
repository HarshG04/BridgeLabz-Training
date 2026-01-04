using System;

class Product
{
    public static double Discount = 5.0;

    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
        Console.WriteLine($"Discount updated to {Discount}%");
    }

    public readonly int ProductID;
    public string ProductName;
    public double Price;
    public int Quantity;

    public Product(int ProductID, string ProductName, double Price, int Quantity)
    {
        this.ProductID = ProductID;
        this.ProductName = ProductName;
        this.Price = Price;
        this.Quantity = Quantity;
    }

    public static void ShowProductDetails(object obj)
    {
        if (obj is Product p)
        {
            Console.WriteLine("\n--- Product Details ---");
            Console.WriteLine($"Product ID    : {p.ProductID}");
            Console.WriteLine($"Name          : {p.ProductName}");
            Console.WriteLine($"Price         : {p.Price}");
            Console.WriteLine($"Quantity      : {p.Quantity}");
            Console.WriteLine($"Discount      : {Discount}%");

            double total = p.Price * p.Quantity;
            double finalAmount = total - (total * Discount / 100);

            Console.WriteLine($"Total Amount  : {total}");
            Console.WriteLine($"Final Amount  : {finalAmount}");
        }
        else
        {
            Console.WriteLine("\nObject is NOT a Product!");
        }
    }
}

class Program
{
    static void Main()
    {
        Product p1 = new Product(101, "Laptop", 50000, 1);
        Product p2 = new Product(102, "Headphones", 2000, 2);

        Product.ShowProductDetails(p1);
        Product.ShowProductDetails(p2);

        Product.UpdateDiscount(10);

        Product.ShowProductDetails(p1);

        Product.ShowProductDetails("Hello");
    }
}
