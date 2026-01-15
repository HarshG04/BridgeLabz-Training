namespace AddressBookSystem
{
    interface IContact
    {
        // UC-2 
        // Interface Method Signature For Adding New Contact
        void AddNewContact();

        //UC-3 
        //Edit Existing Person based on name
        void EditContact();

        //UC-4
        //Delete Existing Person based on name
        void DeleteContact();

        // UC-5
        // Setting up address book capacity
        // void AddAddressBookCapacity();

        // UC - 11
        // Sorting Contact Data Lexographically based on name and Displaying the sorted data
        void SortByNameAndDisplay();
    }
}