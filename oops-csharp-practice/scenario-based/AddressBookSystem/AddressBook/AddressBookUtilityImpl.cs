namespace AddressBookSystem
{
    class AddAddressBookUtilityImpl : IAddressBook
    {
        // Dictionary To Store All AddressBooks Reference Data With key: Address Book Name
        Dictionary<string,AddressBook> addressBooks = new Dictionary<string, AddressBook>();

        // Method To Add New Address Book In Dictionary
        public void AddNewAddressBook()
        {
            Console.Write("Enter The Name Of Your Address Book: ");
            string name = Console.ReadLine();

            // Checking If book already exists
            if (addressBooks.ContainsKey(name.ToLower()))
            {
                Console.WriteLine("Address Book Name Already Exists");
                return;
            }

            // creating a new AddressBook Object To Store
            AddressBook newAddressBook = new AddressBook();
            newAddressBook.AddressBookName = name.ToLower();

            // Setting Up the Capacity Of our Address Book
            Console.Write("Enter Capacity Of Your Address Book: ");
            int capacity = Convert.ToInt32(Console.ReadLine());
            if (capacity <= 0)
            {
                Console.WriteLine("Capacity must be greater than 0");
                return;
            }

            // Assigning contact array with capacity
            newAddressBook.Contacts = new Contact[capacity];

            newAddressBook.StoredContacts = 0;
            newAddressBook.ContactIdx = 0;

            // Storing The New Address Book Inside Dictionary
            addressBooks.Add(newAddressBook.AddressBookName, newAddressBook);

            Console.WriteLine("Your New Address Book Has Created Successfully");
        }

        // Method To Select Any Existing Address Book By Name And Returning Its Reference
        public AddressBook SelectAddressBook()
        {
            // Checking for empty dictionay
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Address Books Available");
                return null;
            }
            Console.WriteLine("You Can Select Any Available Address Book: ");
            
            // Generating a List of All Existing Address Books on Console Screen
            int idx = 1;
            foreach(string addressBookName in addressBooks.Keys)
            {
                Console.WriteLine(idx+": "+addressBookName);
                idx++;
            }

            // Getting Address Book Name User Want To Select
            Console.Write("Enter Address Book Name To Select [n: No Selection]: ");
            string userChoise = Console.ReadLine().ToLower();

            if (userChoise.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("No Address Book Has Chosen..");
                return null;
            }

            // If Address Book exists return reference else return null
            if (addressBooks.ContainsKey(userChoise))
            {
                Console.WriteLine($"Selecting Address Book : {userChoise}");
                return addressBooks[userChoise];
            }
            else
            {
                Console.WriteLine($"No Address Book Has Found Of Name : {userChoise}");
                return null;
            }

        }
    }
}