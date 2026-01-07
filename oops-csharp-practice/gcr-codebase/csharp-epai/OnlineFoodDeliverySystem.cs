using System;
using System.Collections.Generic;

abstract class FoodItem
{
    private string itemName;
    private double price;
    private int quantity;

    public string ItemName { get => itemName; set => itemName = value ?? string.Empty; }
    public double Price { get => price; protected set => price = value < 0 ? 0 : value; }
    public int Quantity { get => quantity; set => quantity = value < 0 ? 0 : value; }

    internal virtual string GetInternalInfo() => "FoodItem";

    public FoodItem(string itemName, double price, int quantity)
    {
        ItemName = itemName;
        Price = price;
        Quantity = quantity;
    }

    public abstract double CalculateTotalPrice();

    public void GetItemDetails()
    {
        Console.WriteLine($"{ItemName}: {Quantity} x {Price:C}");
    }
}

interface IDiscountable
{
    void ApplyDiscount(double percent);
    string GetDiscountDetails();
}

class VegItem : FoodItem, IDiscountable
{
    private double discountPercent = 0;

    public VegItem(string name, double price, int qty) : base(name, price, qty) { }

    internal override string GetInternalInfo() => "VegItem";

    public override double CalculateTotalPrice() => Price * Quantity * (1 - discountPercent / 100);

    public void ApplyDiscount(double percent) => discountPercent = percent;

    public string GetDiscountDetails() => $"{discountPercent}% off";
}

class NonVegItem : FoodItem, IDiscountable
{
    private double discountPercent = 0;
    private double extraChargePerItem = 2.0;

    public NonVegItem(string name, double price, int qty) : base(name, price, qty) { }

    internal override string GetInternalInfo() => "NonVegItem";

    public override double CalculateTotalPrice() => (Price + extraChargePerItem) * Quantity * (1 - discountPercent / 100);

    public void ApplyDiscount(double percent) => discountPercent = percent;

    public string GetDiscountDetails() => $"{discountPercent}% off, extra {extraChargePerItem:C} per item";
}

class ProgramFoodDelivery
{
    static void Main()
    {
        var menu = new List<FoodItem>
        {
            new VegItem("Paneer Roll", 5.5, 2),
            new NonVegItem("Chicken Wrap", 7.0, 1)
        };

        ((IDiscountable)menu[0]).ApplyDiscount(10);
        ((IDiscountable)menu[1]).ApplyDiscount(5);

        foreach (var item in menu)
        {
            item.GetItemDetails();
            Console.WriteLine($"Total: {item.CalculateTotalPrice():C}");
            if (item is IDiscountable d)
                Console.WriteLine(d.GetDiscountDetails());
            Console.WriteLine();
        }
    }
}
