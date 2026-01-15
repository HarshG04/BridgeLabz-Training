namespace AddressBookSystem
{
    class AddressBookUtilityImpl : IAddressBook
    {
        // Dictionary To Store All AddressBooks Reference Data With key: Address Book Name
        private Dictionary<string,AddressBook> addressBooks = new Dictionary<string, AddressBook>();
        

        
        internal Dictionary<string,LinkedList<Contact>> personByCity = new Dictionary<string, LinkedList<Contact>>(); // mantaining a Dictionary Of City and Person
        internal Dictionary<string,LinkedList<Contact>> personByState = new Dictionary<string, LinkedList<Contact>>(); // mantaining a Dictionary Of State and Person

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
    
    
        // method for searching person based on city or state across multiple address books
        public void SearchByCityOrState()
        {
            if(addressBooks.Count == 0)
            {
                Console.WriteLine("No Address Books Available");
                return;
            }
            
            while(true){
                Console.WriteLine("Search by City Or State [1: city, 2: state, 3: no search]: ");
                Console.Write("Enter Your Choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1 : SearchByCity();
                            return;
                    case 2 : SearchByState();
                            return;
                    case 3 : return;
                    default : break;
                }
            }
        }

        // private helper method for searching based on city
        private void SearchByCity()
        {
            Console.Write("Enter city name to search: ");
            string city = Console.ReadLine().ToLower();

            if (!personByCity.ContainsKey(city))
            {
                Console.WriteLine("No person found in this city");
                return;
            }

            Console.WriteLine("\n==Person's List Based On City: ==\n");

            // Accessing city key data from personByCity Dictionary
            foreach (Contact contact in personByCity[city])
            {
                DisplayPersonInfo(contact);
            }
        }

        // private helper method for searching based on city
        private void SearchByState()
        {
            Console.Write("Enter State to search: ");
            string state = Console.ReadLine().ToLower();

            if (!personByState.ContainsKey(state))
            {
                Console.WriteLine("No person found in this State");
                return;
            }

            Console.WriteLine("\n==Person's List Based On State: ==\n");

            // Accessing state key data from personByState Dictionary
            foreach (Contact contact in personByState[state])
            {
                DisplayPersonInfo(contact);
            }
        }

        // private helper function for Displaying Contact Information
        private void DisplayPersonInfo(Contact contact)
        {
            Console.WriteLine(contact);
            
        }


        // method for counting person based on city or state across multiple address books
        public void CountByCityOrState()
        {
            if(addressBooks.Count == 0)
            {
                Console.WriteLine("No Address Books Available");
                return;
            }
            
            while(true){
                Console.WriteLine("Count Contacts by City Or State [1: city, 2: state, 3: no search]: ");
                Console.Write("Enter Your Choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1 : CountByCity();
                            return;
                    case 2 : CountByState();
                            return;
                    case 3 : return;
                    default : break;
                }
            }
        }

        // private helper method for Count based on city
        private void CountByCity()
        {
            Console.Write("Enter City Name: ");
            string city = Console.ReadLine().ToLower();

            if (!personByCity.ContainsKey(city))
            {
                Console.WriteLine("No person found in this city");
                return;
            }

            Console.WriteLine($"No of Persons in City {city} : {personByCity[city].Count}");
        }

        // private helper method for Count based on State
        private void CountByState()
        {
            Console.Write("Enter State Name: ");
            string state = Console.ReadLine().ToLower();

            if (!personByState.ContainsKey(state))
            {
                Console.WriteLine("No person found in this State");
                return;
            }

            Console.WriteLine($"No of Persons in State {state} : {personByState[state].Count}");
        }

    }
}