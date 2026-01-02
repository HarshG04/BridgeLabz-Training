class CarRentalSystem
{
    string customerName, carModel;
    int rentalDays;

    CarRentalSystem(string name,string model,int days)
    {
        this.customerName = name;
        this.carModel = model;
        this.rentalDays = days;
    }

    void CalculateTotalCost()
    {
        Console.WriteLine($"Enter cost of {this.carModel} for one day : ");
        int cost = Convert.ToInt32(Console.ReadLine());
        int totalCost = cost*this.rentalDays;
        Console.WriteLine($"totalCost : {totalCost}");
    }

    static void Main()
    {
        CarRentalSystem c1 = new CarRentalSystem("aditya","dhoom1",5);
        c1.CalculateTotalCost();
    }
}