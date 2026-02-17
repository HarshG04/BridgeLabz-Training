namespace HealthClinicApp.Exceptions;
class InvalidInputException : Exception
{
    public InvalidInputException(string Message)
    : base(Message) {}
}