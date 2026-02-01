namespace FutureLogistics;

class BrickTransport : GoodsTransport
{
    private float BrickSize;
    private int BrickQuantity;

    private float BrickPrice;


    public BrickTransport(string TransportId,string TransportDate,int TransportRating,float BrickSize,int BrickQuantity,float BrickPrice)
    : base(TransportId, TransportDate, TransportRating)
    {
        this.BrickSize = BrickSize;
        this.BrickQuantity = BrickQuantity;
        this.BrickPrice = BrickPrice;
    }

    public float GetBrickSize() => BrickSize;
    public int GetBrickQuantity() => BrickQuantity;
    public float GetBrickPrice() => BrickPrice;

    public override string VehicleSelection()
    {
        if(BrickQuantity<300) return "Truck";
        else if(BrickQuantity>=300 && BrickQuantity<=500) return "Lorry";
        else return "MonsterLorry";
    }


    public override float CalculateTotalCharge()
    {
        float totalBrickPrice = BrickPrice * BrickQuantity;

        string vehicle = VehicleSelection();
        int vehicleCharge = 0;
        if(vehicle.Equals("Truck")) vehicleCharge = 1000;
        else if(vehicle.Equals("Lorry")) vehicleCharge = 1700;
        else vehicleCharge = 3000;

        float tax = totalBrickPrice * 0.3f;

        float discount = 0f;

        if(TransportRating==5) discount = totalBrickPrice*0.2f;
        else if(TransportRating==3 || TransportRating==4) discount = totalBrickPrice*0.1f;

        float totalCharge = totalBrickPrice + vehicleCharge + tax  - discount;

        return totalCharge;

    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Transport Id : {GetTransportId()}");
        Console.WriteLine($"Date Of Transport : {GetTransportDate()}");
        Console.WriteLine($"Rating Of Transport : {GetTransportRating()}");
        Console.WriteLine($"Quantity Of Bricks : {GetBrickQuantity()}");
        Console.WriteLine($"Brick Price : {GetBrickPrice()}");
        Console.WriteLine($"Vehicle for transport : {VehicleSelection()}");
        Console.WriteLine($"Total charge : {CalculateTotalCharge()}");
    }


}