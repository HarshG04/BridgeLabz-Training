namespace AddressBookSystem
{

    /// <summary>
    /// The Address Book System is a Program where We Can Store Persons's Contact Information And Manage Them
    /// First We have a AddressBookMain Method which has a object of AddressBookMenu class , which has a Start Method and Displaying the Welcome Message
    /// 
    /// UC 1 : Created a Class Of Contact with some fields for stroing a Person's Information 
    /// UC 2 : Added a Method To Adding New Contact 
    ///
    /// </summary>

    class AddressBookMain
    {
        public static void Main(string[] args)
        {
            AddressBookMenu addressMenu = new AddressBookMenu();
            addressMenu.Start();
        }
    }
}