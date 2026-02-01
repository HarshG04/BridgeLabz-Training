namespace FutureLogistics;

abstract class GoodsTransport
{
    protected string TransportId{get;set;}
    protected string TransportDate{get;set;}
    protected int TransportRating{get;set;}

    public GoodsTransport(string transportId, string transportDate, int transportRating)
    {
        TransportId = transportId;
        TransportDate = transportDate;
        TransportRating = transportRating;
    }

    public string GetTransportId() => TransportId;
    public string GetTransportDate() => TransportDate;
    public int GetTransportRating() => TransportRating;

    abstract public string VehicleSelection();

    abstract public float CalculateTotalCharge();

    abstract  public void DisplayDetails();



}