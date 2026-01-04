using System;

class Vehicle
{
    public static double registrationFee = 5000;
    public static void UpdateRegistrationFee(double newFee)
    {
        Vehicle.registrationFee = newFee;
    }

    public string ownerName;
    public string vehicleType;
    public readonly string registrationNumber;

    public Vehicle(string ownerName, string vehicleType, string registrationNumber)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
        this.registrationNumber = registrationNumber;
    }

    public static void ShowVehicleDetails(object obj)
    {
        if (obj is Vehicle v)
        {
            Console.WriteLine("\nVehicle Details");
            Console.WriteLine("Owner: " + v.ownerName);
            Console.WriteLine("Type: " + v.vehicleType);
            Console.WriteLine("Registration Number: " + v.registrationNumber);
            Console.WriteLine("Registration Fee: " + registrationFee);
        }
        else
        {
            Console.WriteLine("Object is not a Vehicle");
        }
    }
}

class Program1
{
    static void Main()
    {
        Vehicle v1 = new Vehicle("Harsh", "Car", "A258");
        Vehicle v2 = new Vehicle("Aditya", "Bike", "A169");

        Vehicle.ShowVehicleDetails(v1);
        Vehicle.ShowVehicleDetails(v2);

        Vehicle.UpdateRegistrationFee(6500);

        Vehicle.ShowVehicleDetails(v1);
    }
}
