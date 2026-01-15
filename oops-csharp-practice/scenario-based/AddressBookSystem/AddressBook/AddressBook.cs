namespace AddressBookSystem
{
    class AddressBook
    {
        public string AddressBookName{get;set;}
        public int StoredContacts{get;set;} // no of stored contacts
        public Contact[] Contacts{get;set;} // contact array
        public int ContactIdx{get;set;}     // contact array index to point last/next available space

        
    }
}