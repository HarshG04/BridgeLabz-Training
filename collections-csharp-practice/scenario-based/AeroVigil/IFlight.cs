namespace AeroVigil;

interface IFlight
{
    void EnterFlighDetailsAndValide();
    bool ValidateFlightNumber(string FlightNumber);
    bool ValidateFlightName(string FlightName);
    bool ValidatePassengerCount(int passengerCount, string flightName);
    double CalculateFuelToFillTank(string flightName, double currentFuelLevel);

}