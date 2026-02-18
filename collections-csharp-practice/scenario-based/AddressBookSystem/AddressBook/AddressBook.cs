namespace AddressBookSystem
{
    class AddressBook
    {
        public string AddressBookName{get;set;}
        public List<Contact> Contacts{get;} = new List<Contact>();
           
    }
}