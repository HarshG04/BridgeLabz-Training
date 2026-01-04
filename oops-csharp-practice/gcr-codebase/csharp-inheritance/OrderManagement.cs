using System;

public class Order
{
    public int orderId;
    public DateTime orderDate;
    public virtual string GetOrderStatus()
    {
        return "Order placed";
    }
}

public class ShippedOrder : Order
{
    public string trackingNumber;
    public override string GetOrderStatus()
    {
        return $"Shipped - Tracking: {trackingNumber}";
    }
}

public class DeliveredOrder : ShippedOrder
{
    public DateTime deliveryDate;
    public override string GetOrderStatus()
    {
        return $"Delivered on {deliveryDate:d}";
    }
}

public class Program
{
    public static void Main()
    {
        Order order = new Order { orderId = 1, orderDate = DateTime.Today };
        ShippedOrder shipped = new ShippedOrder { orderId = 2, orderDate = DateTime.Today.AddDays(-2), trackingNumber = "TRK123" };
        DeliveredOrder delivered = new DeliveredOrder { orderId = 3, orderDate = DateTime.Today.AddDays(-5), trackingNumber = "TRK456", deliveryDate = DateTime.Today.AddDays(-1) };
        Console.WriteLine(order.GetOrderStatus());
        Console.WriteLine(shipped.GetOrderStatus());
        Console.WriteLine(delivered.GetOrderStatus());
    }
}
