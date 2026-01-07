using System;
using System.Collections.Generic;

abstract class VehicleRide
{
    private string vehicleId;
    private string driverName;
    private double ratePerKm;

    public string VehicleId { get => vehicleId; set => vehicleId = value ?? string.Empty; }
    public string DriverName { get => driverName; set => driverName = value ?? string.Empty; }
    public double RatePerKm { get => ratePerKm; set => ratePerKm = value < 0 ? 0 : value; }

    internal virtual string GetInternalInfo() => "RideVehicle";

    public VehicleRide(string vehicleId, string driverName, double ratePerKm)
    {
        VehicleId = vehicleId;
        DriverName = driverName;
        RatePerKm = ratePerKm;
    }

    public void GetVehicleDetails() => Console.WriteLine($"ID:{VehicleId}, Driver:{DriverName}, RatePerKm:{RatePerKm:C}");

    public abstract double CalculateFare(double distance);
}

interface IGPS
{
    string GetCurrentLocation();
    void UpdateLocation(string location);
}

class CarRide : VehicleRide, IGPS
{
    private string location = "Unknown";

    public CarRide(string id, string driver, double rate) : base(id, driver, rate) { }

    internal override string GetInternalInfo() => "Car";

    public override double CalculateFare(double distance) => RatePerKm * distance + 2.0; // base charge

    public string GetCurrentLocation() => location;

    public void UpdateLocation(string location) => this.location = location;
}

class BikeRide : VehicleRide, IGPS
{
    private string location = "Unknown";

    public BikeRide(string id, string driver, double rate) : base(id, driver, rate) { }

    internal override string GetInternalInfo() => "Bike";

    public override double CalculateFare(double distance) => RatePerKm * distance;

    public string GetCurrentLocation() => location;

    public void UpdateLocation(string location) => this.location = location;
}

class AutoRide : VehicleRide, IGPS
{
    private string location = "Unknown";

    public AutoRide(string id, string driver, double rate) : base(id, driver, rate) { }

    internal override string GetInternalInfo() => "Auto";

    public override double CalculateFare(double distance) => RatePerKm * distance + 0.5; // small base

    public string GetCurrentLocation() => location;

    public void UpdateLocation(string location) => this.location = location;
}

class ProgramRideHailing
{
    static void Main()
    {
        var fleet = new List<VehicleRide>
        {
            new CarRide("V1", "Gina", 1.2),
            new BikeRide("V2", "Hank", 0.5),
            new AutoRide("V3", "Ivy", 0.8)
        };

        foreach (var v in fleet)
        {
            v.GetVehicleDetails();
            Console.WriteLine($"Fare for 10km: {v.CalculateFare(10):C}");
            if (v is IGPS gps)
            {
                gps.UpdateLocation("Downtown");
                Console.WriteLine($"Location: {gps.GetCurrentLocation()}");
            }
            Console.WriteLine();
        }
    }
}
