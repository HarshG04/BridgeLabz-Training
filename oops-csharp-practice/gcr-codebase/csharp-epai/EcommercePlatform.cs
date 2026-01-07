using System;

abstract class Product
{
    private int productId;
    private string name;
    double price;

    public Product(int id, string name, double price)
    {
        this.productId = id;
        this.name = name;
        this.price = price;
    }

    public abstract double CalculateDiscount();

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public string GetName()
    {
        return name;
    }
}

interface ITaxable
{
    double CalculateTax();
    void GetTaxDetails();
}


class Electronics : Product, ITaxable
{
    double tax;
    double discount;

    public Electronics(int id, string name, double price, double tax, double discount)
        : base(id, name, price)
    {
        this.tax = tax;
        this.discount = discount;
    }

    public override double CalculateDiscount()
    {
        return price * (discount / 100);
    }

    public double CalculateTax()
    {
        return price * (tax / 100);
    }

    public void GetTaxDetails()
    {
        Console.WriteLine("Electronics Tax = " + CalculateTax());
    }
}


class Clothing : Product, ITaxable
{
    double tax;
    double discount;

    public Clothing(int id, string name, double price, double tax, double discount)
        : base(id, name, price)
    {
        this.tax = tax;
        this.discount = discount;
    }

    public override double CalculateDiscount()
    {
        return price * (discount / 100);
    }

    public double CalculateTax()
    {
        return price * (tax / 100);
    }

    public void GetTaxDetails()
    {
        Console.WriteLine("Clothing Tax = " + CalculateTax());
    }
}


class Groceries : Product, ITaxable
{
    double tax;
    double discount;

    public Groceries(int id, string name, double price, double tax, double discount)
        : base(id, name, price)
    {
        this.tax = tax;
        this.discount = discount;
    }

    public override double CalculateDiscount()
    {
        return price * (discount / 100);
    }

    public double CalculateTax()
    {
        return price * (tax / 100);
    }

    public void GetTaxDetails()
    {
        Console.WriteLine("Groceries Tax = " + CalculateTax());
    }
}


class PriceCalculator
{
    public static void PrintFinalPrice(Product p, ITaxable t)
    {
        double tax = t.CalculateTax();
        double discount = p.CalculateDiscount();

        double finalPrice = p is Product ? ((dynamic)p).price + tax - discount : 0;

        Console.WriteLine($"Final Price of {p.GetName()} = {finalPrice}");
    }
}


class Program
{
    static void Main()
    {
        Product p1 = new Electronics(1, "Laptop", 50000, 18, 10);
        Product p2 = new Clothing(2, "Shirt", 2000, 5, 20);
        Product p3 = new Groceries(3, "Rice Bag", 1000, 2, 5);

        PriceCalculator.PrintFinalPrice(p1, (ITaxable)p1);
        PriceCalculator.PrintFinalPrice(p2, (ITaxable)p2);
        PriceCalculator.PrintFinalPrice(p3, (ITaxable)p3);
    }
}
