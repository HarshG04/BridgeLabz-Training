class HotelBookingSystem
{
    string guestName;
    string roomType;
    int night;

    HotelBookingSystem(){}
    HotelBookingSystem(string name,string type,int night)
    {
        this.guestName = name;
        this.roomType = type;
        this.night = night;
    }
    HotelBookingSystem(HotelBookingSystem p)
    {
        this.guestName = p.guestName;
        this.roomType = p.roomType;
        this.night = p.night;
    }
    void ShowDetails()
    {
        Console.WriteLine(this.guestName);
        Console.WriteLine(this.roomType);
        Console.WriteLine(this.night);
    }

    static void Main()
    {
        HotelBookingSystem p1 = new HotelBookingSystem("harsh","normal",2);
        p1.ShowDetails();
    }
}
