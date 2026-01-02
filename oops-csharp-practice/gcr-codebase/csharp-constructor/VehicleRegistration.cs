using System;

class Vehicle
{
    private string ownerName;
    private string vehicleType;

    private static double registrationFee = 5000;

    public Vehicle(string ownerName, string vehicleType)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
    }

    public void DisplayVehicleDetails()
    {
        Console.WriteLine($"Owner Name     : {ownerName}");
        Console.WriteLine($"Vehicle Type   : {vehicleType}");
        Console.WriteLine($"Registration Fee: {registrationFee}");
        Console.WriteLine();
    }

    public static void UpdateRegistrationFee(double newFee)
    {
        registrationFee = newFee;
        Console.WriteLine($"Registration fee updated to {registrationFee}\n");
    }
}


class Program
{
    static void Main()
    {
        Vehicle v1 = new Vehicle("Harsh", "Car");
        Vehicle v2 = new Vehicle("Ravi", "Bike");

        Console.WriteLine("Before fee update:");
        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();

        Vehicle.UpdateRegistrationFee(6500);

        Console.WriteLine("After fee update:");
        v1.DisplayVehicleDetails();
        v2.DisplayVehicleDetails();
    }
}
