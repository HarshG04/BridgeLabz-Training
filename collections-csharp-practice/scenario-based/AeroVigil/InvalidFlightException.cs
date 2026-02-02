namespace AeroVigil;

class InvalidFlightExcption : Exception
{
    string FlightNumber;
    public InvalidFlightExcption(string Message)
     : base(Message){}

}