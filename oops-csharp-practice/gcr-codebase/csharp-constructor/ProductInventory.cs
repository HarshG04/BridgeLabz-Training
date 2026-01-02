class Product
{
    static int totalProducts;
    string  productName;
    int price;

    Product(string name,int price)
    {
        this.productName = name;
        this.price = price;
        Product.totalProducts++;
    }

    void DisplayProductDetails()
    {
        Console.WriteLine("Product Name : "+this.productName);
        Console.WriteLine("Product Price : "+this.price);
    }

    static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products : " + Product.totalProducts);
    }

    static void Main()
    {
        Product p1 = new Product("B1",250);
        p1.DisplayProductDetails();
        Product.DisplayTotalProducts();
        Product p2 = new Product("B2",650);
        p2.DisplayProductDetails();
        Product.DisplayTotalProducts();

    }
}