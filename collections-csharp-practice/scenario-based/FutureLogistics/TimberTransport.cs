namespace FutureLogistics;

class TimberTransport : GoodsTransport
{
    private float TimberLength;
    private float TimberRadius;

    private string TimberType;
    private float TimberPrice;


    public TimberTransport(string TransportId,string TransportDate,int TransportRating,float TimberLength,float TimberRadius,string TimberType,float TimberPrice)
    : base(TransportId, TransportDate, TransportRating)
    {
        this.TimberLength = TimberLength;
        this.TimberRadius = TimberRadius;
        this.TimberType = TimberType;
        this.TimberPrice = TimberPrice;
    }

    public string GetTimberType() => TimberType;
    public float GetTimberPrice() => TimberPrice;
 
 

    public override string VehicleSelection()
    {
        float area = 2 * 3.147f * TimberRadius * TimberLength;

        switch (area)
        {
            case < 250 :  return "Truck";
            case >=250 and <=400 : return "Lorry";
            case > 400 : return "MonsterLorry";
        }

        return null;
    }


    public override float CalculateTotalCharge()
    {

        float timberTypeCost = 0.15f;
        if(TimberType.Equals("Premium")) timberTypeCost = 0.25f;

        float volume = 3.147f * TimberRadius * TimberRadius * TimberLength;

        float totalTimberPrice = volume * TimberPrice * timberTypeCost;

        float tax = totalTimberPrice * 0.3f;

        float discount = 0;
        if(TransportRating==5) discount = totalTimberPrice*0.2f;
        else if(TransportRating==3 || TransportRating==4) discount = totalTimberPrice*0.1f;

        string vehicleType = VehicleSelection();

        float vehicleCost = 3000;
        if(vehicleType.Equals("Truck")) vehicleCost = 1000;
        else if(vehicleType.Equals("Lorry")) vehicleCost = 1700;

        float totalCharge = totalTimberPrice + vehicleCost + tax - discount;

        return totalCharge;
        
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"Transport Id : {GetTransportId()}");
        Console.WriteLine($"Date Of Transport : {GetTransportDate()}");
        Console.WriteLine($"Rating Of Transport : {GetTransportRating()}");
        Console.WriteLine($"Type Of The Timber : {GetTimberType()}");
        Console.WriteLine($"Timber price per kilo : {GetTimberPrice()}");
        Console.WriteLine($"Vehicle for transport : {VehicleSelection()}");
        Console.WriteLine($"Total charge : {CalculateTotalCharge()}");
    }


}