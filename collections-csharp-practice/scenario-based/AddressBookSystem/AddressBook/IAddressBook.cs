namespace AddressBookSystem
{
    interface IAddressBook
    {
        void AddNewAddressBook();   // for adding new Address Book
        AddressBook SelectAddressBook();    // Select any existing address book by name

        // UC-8 
        void SearchByCityOrState(); //search Person by City or State across the multiple Address Books

        // UC 10
        void CountByCityOrState(); // Ability to get number of contact persons i.e. count by City or State
    }
}