namespace AddressBookSystem
{
    interface IAddressBook
    {
        void AddNewAddressBook();   // for adding new Address Book
        AddressBook SelectAddressBook();    // Select any existing address book by name
    }
}