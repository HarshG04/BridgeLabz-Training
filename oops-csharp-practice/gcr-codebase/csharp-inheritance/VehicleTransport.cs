using System;

public class Vehicle
{
    public int maxSpeed;
    public string fuelType;
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"MaxSpeed: {maxSpeed}, FuelType: {fuelType}");
    }
}

public class Car : Vehicle
{
    public int seatCapacity;
    public override void DisplayInfo()
    {
        Console.WriteLine($"Car - MaxSpeed: {maxSpeed}, FuelType: {fuelType}, SeatCapacity: {seatCapacity}");
    }
}

public class Truck : Vehicle
{
    public int payloadCapacity;
    public override void DisplayInfo()
    {
        Console.WriteLine($"Truck - MaxSpeed: {maxSpeed}, FuelType: {fuelType}, PayloadCapacity: {payloadCapacity}");
    }
}

public class Motorcycle : Vehicle
{
    public bool hasSidecar;
    public override void DisplayInfo()
    {
        Console.WriteLine($"Motorcycle - MaxSpeed: {maxSpeed}, FuelType: {fuelType}, HasSidecar: {hasSidecar}");
    }
}

public class Program
{
    public static void Main()
    {
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car { maxSpeed = 200, fuelType = "Petrol", seatCapacity = 5 },
            new Truck { maxSpeed = 120, fuelType = "Diesel", payloadCapacity = 10000 },
            new Motorcycle { maxSpeed = 180, fuelType = "Petrol", hasSidecar = false }
        };
        foreach (var v in vehicles)
        {
            v.DisplayInfo();
        }
    }
}
