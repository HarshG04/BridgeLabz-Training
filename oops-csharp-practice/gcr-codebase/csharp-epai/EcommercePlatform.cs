/*
Description: Develop a simplified e-commerce platform:
Create an abstract class Product with fields like productId, name, and price, and an abstract method CalculateDiscount().
Extend it into concrete classes: Electronics, Clothing, and Groceries.
Implement an interface ITaxable with methods CalculateTax() and GetTaxDetails() for applicable product categories.
Use encapsulation to protect product details, allowing updates only through setter methods.
Showcase polymorphism by creating a method that calculates and prints the final price (price + tax - discount) for a list of products.

*/

abstract class Product {
    int productId;
    string name;
    double price;

    public Product(int id,string name,double price)
    {
        this.productId = id;
        this.name = name;
        this.price = price;
    }
    abstract virtual void CalculateDiscount();
}


class Electronics : Product , ITaxable
{
    double tax;
    double discount;
    public Electronics(int id,string name,double price,double tax,double discount) : base(id, name, price)
    {
        this.tax = tax;
        this.discount = discount;
    }

    public double CalculateTax()
    {
        return price*(tax/100);
    }

    public void GetTaxDetails()
    {
        double tax = CalculateTax();
        Console.WriteLine("Tax Price" + tax);
    }
} 

class Clothing : Product , ITaxable
{
    double tax;
    double discount;
    public Clothing(int id,string name,double price,double tax,double discount) : base(id, name, price)
    {
        this.tax = tax;
        this.discount = discount;
    }
    public double CalculateTax()
    {
        return price*(tax/100);
    }
    public double CalculateDiscount()
    {
        double dis = price*(discount/100);
        return dis;
    }

    public void GetTaxDetails()
    {
        double tax = CalculateTax();
        Console.WriteLine("Tax Price" + tax);
    }



}

class Groceries : Product , ITaxable
{
    double tax;
    double discount;
    public Groceries(int id,string name,double price,double tax,double discount) : base(id, name, price)
    {
        this.tax = tax;
        this.discount = discount;
    }
    public double CalculateTax()
    {
        return price*(tax/100);
    }

    public void GetTaxDetails()
    {
        double tax = CalculateTax();
        Console.WriteLine("Tax Price" + tax);
    }
}

interface ITaxable
{
    public double CalculateTax();
    public void GetTaxDetails();
}
