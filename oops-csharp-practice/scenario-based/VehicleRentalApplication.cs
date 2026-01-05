class Vehicle
{
    protected string vehicleId;
    protected string model;
    protected bool isAvailable;

    public Vehicle(string vehicleId, string model)
    {
        this.vehicleId = vehicleId;
        this.model = model;
        this.isAvailable = true;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Vehicle ID: {vehicleId}, Model: {model}, Available: {isAvailable}");
    }
}

class Bike : Vehicle, IRentable
{
    private int dailyRate;

    public Bike(string vehicleId, string model, int dailyRate)
        : base(vehicleId, model)
    {
        this.dailyRate = dailyRate;
    }

    public int CalculateRent(int days)
    {
        return dailyRate * days;
    }
}

interface IRentable
{
    int CalculateRent(int days);
}

class Car : Vehicle, IRentable
{
    private int dailyRate;

    public Car(string vehicleId, string model, int dailyRate)
        : base(vehicleId, model)
    {
        this.dailyRate = dailyRate;
    }

    public int CalculateRent(int days)
    {
        return dailyRate * days;
    }
}

class Truck : Vehicle, IRentable
{
    private int dailyRate;

    public Truck(string vehicleId, string model, int dailyRate)
        : base(vehicleId, model)
    {
        this.dailyRate = dailyRate;
    }

    public int CalculateRent(int days)
    {
        return dailyRate * days;
    }
}

class Customer
{
    private string customerId;
    private string name;

    public Customer(string customerId, string name)
    {
        this.customerId = customerId;
        this.name = name;
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Customer ID: {customerId}, Name: {name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bike bike = new Bike("B001", "Broom1", 500);
        Car car = new Car("C001", "Dhoom1", 1500);
        Truck truck = new Truck("T001", "Truck1", 2500);

        Customer customer = new Customer("CU001", "harsh");

        bike.ShowDetails();
        car.ShowDetails();
        truck.ShowDetails();
        customer.ShowDetails();

        int bikeRent = bike.CalculateRent(3);
        int carRent = car.CalculateRent(2);
        int truckRent = truck.CalculateRent(1);

        Console.WriteLine($"Bike Rent for 3 days: INR {bikeRent}");
        Console.WriteLine($"Car Rent for 2 days: INR {carRent}");
        Console.WriteLine($"Truck Rent for 1 day: INR {truckRent}");
    }
}



