using System;

public class Vehicle
{
    public int maxSpeed;
    public string model;
}

public interface IRefuelable
{
    void Refuel();
}

public class PetrolVehicle : Vehicle, IRefuelable
{
    public void Refuel()
    {
        Console.WriteLine($"PetrolVehicle {model} refueling");
    }
}

public class ElectricVehicle : Vehicle
{
    public void Charge()
    {
        Console.WriteLine($"ElectricVehicle {model} charging");
    }
}

public class Program
{
    public static void Main()
    {
        PetrolVehicle petrol = new PetrolVehicle { model = "ab", maxSpeed = 180 };
        ElectricVehicle electric = new ElectricVehicle { model = "cd", maxSpeed = 160 };
        petrol.Refuel();
        electric.Charge();
    }
}
