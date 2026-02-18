namespace AddressBookSystem;

class InvalidAddressBookException : Exception
{
    public InvalidAddressBookException(string m) : base(m){}
}