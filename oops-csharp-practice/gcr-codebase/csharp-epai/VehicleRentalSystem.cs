using System;
using System.Collections.Generic;

abstract class Vehicle
{
    private string vehicleNumber;
    private string type;
    private double rentalRate;

    public string VehicleNumber
    {
        get => vehicleNumber;
        set => vehicleNumber = value ?? string.Empty;
    }

    public string Type
    {
        get => type;
        set => type = value ?? string.Empty;
    }

    public double RentalRate
    {
        get => rentalRate;
        set => rentalRate = value < 0 ? 0 : value;
    }

    internal virtual string GetInternalInfo() => "BaseVehicle";

    public Vehicle(string vehicleNumber, string type, double rentalRate)
    {
        VehicleNumber = vehicleNumber;
        Type = type;
        RentalRate = rentalRate;
    }

    public abstract double CalculateRentalCost(int days);
}

interface IInsurable
{
    double CalculateInsurance();
    string GetInsuranceDetails();
}

class Car : Vehicle, IInsurable
{
    private string policyNumber;

    public Car(string num, double rate, string policyNumber) : base(num, "Car", rate)
    {
        this.policyNumber = policyNumber;
    }

    internal override string GetInternalInfo() => "Car";

    public override double CalculateRentalCost(int days) => RentalRate * days + 20; // fixed cleaning

    public double CalculateInsurance() => 0.02 * RentalRate * 365; // yearly approx based

    public string GetInsuranceDetails() => $"Policy: ****{(policyNumber.Length>4?policyNumber[^4..]:policyNumber)}";
}

class Bike : Vehicle, IInsurable
{
    private string policyNumber;

    public Bike(string num, double rate, string policyNumber) : base(num, "Bike", rate)
    {
        this.policyNumber = policyNumber;
    }

    internal override string GetInternalInfo() => "Bike";

    public override double CalculateRentalCost(int days) => RentalRate * days;

    public double CalculateInsurance() => 0.01 * RentalRate * 365;

    public string GetInsuranceDetails() => $"Policy: ****{(policyNumber.Length>4?policyNumber[^4..]:policyNumber)}";
}

class Truck : Vehicle, IInsurable
{
    private string policyNumber;

    public Truck(string num, double rate, string policyNumber) : base(num, "Truck", rate)
    {
        this.policyNumber = policyNumber;
    }

    internal override string GetInternalInfo() => "Truck";

    public override double CalculateRentalCost(int days) => RentalRate * days + 100; // heavy vehicle surcharge

    public double CalculateInsurance() => 0.05 * RentalRate * 365;

    public string GetInsuranceDetails() => $"Policy: ****{(policyNumber.Length>4?policyNumber[^4..]:policyNumber)}";
}

class ProgramVehicleRental
{
    static void Main()
    {
        var vehicles = new List<Vehicle>
        {
            new Car("C-100", 50, "CARPOL123456"),
            new Bike("B-200", 15, "BIKPOL654321"),
            new Truck("T-300", 200, "TRKPOL999999")
        };

        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Vehicle: {vehicle.VehicleNumber}, Type: {vehicle.Type}");
            Console.WriteLine($"Rental (3 days): {vehicle.CalculateRentalCost(3):C}");
            if (vehicle is IInsurable ins)
            {
                Console.WriteLine($"Insurance: {ins.CalculateInsurance():C}, Details: {ins.GetInsuranceDetails()}");
            }
            Console.WriteLine();
        }
    }
}
