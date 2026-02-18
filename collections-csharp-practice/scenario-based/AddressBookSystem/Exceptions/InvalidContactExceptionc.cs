namespace AddressBookSystem;

class InvalidContactException : Exception
{
    public InvalidContactException(string m) : base(m){}
}