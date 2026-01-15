namespace AddressBookSystem
{

    /// <summary>
    /// The Address Book System is a Program where We Can Store Persons's Contact Information And Manage Them
    /// First We have a AddressBookMain Method which has a object of AddressBookMenu class , which has a Start Method and Displaying the Welcome Message
    /// 
    /// UC 1 : Created a Class Of Contact with some fields for stroing a Person's Information 
    /// UC 2 : Added a Method To Adding New Contact
    /// UC 3 : Added a New Method for Editing The Contact Information based on first name 
    /// UC 4 : Added a New Method for Deleting The Contact Information based on first name 
    /// UC 5 : Added Contacts Array , New Method SearchByName , Refactored Add, Edit and Delete methods
    /// UC 6 : Added AddressBook class, AddressBook Utility Class, Address Book Interface
    ///         Modified : ContactUtilityImpl class and methods, AddressBookSystemMenu class
    /// UC 7 : Checking For Duplicate Entry By Name Before Adding a New Contact in Address book
    /// UC 8 : Create a Method SearchByCityOrState() Inside AddressBook Utility class to search data based on City or State Across Multiple Address Books
    /// UC 9 : Maintaining Two More Dictionaries in AddressBookUtility PersonByCity and PersonByState
    ///        Modified ContactUtility class and AddressBook Utility class
    /// UC 10 : Ability To count persons based on city and state
    /// UC 11 : Add a method to Sort The contacts array lexicographically by name and display the sorted data
    /// UC 12 : Add a method to Sort The contacts array by city, state or ZIP and display the sorted data
    ///
    /// </summary>

    class AddressBookSystemMain
    {
        public static void Main(string[] args)
        {
            AddressBookSystemMenu addressMenu = new AddressBookSystemMenu();
            addressMenu.Start();
        }
    }
}