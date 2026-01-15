namespace AddressBookSystem
{
    class AddressBookSystemMenu
    {   

        // Creating a private Reference Of IContact Interface
        private IContact contactUtility;

        // Creating a private Reference Of IAddressBook Interface
        private IAddressBook addressBookUtility;


        public void Start()
        {
            Console.WriteLine("Welcome To Address Book Program!!");

            addressBookUtility = new AddressBookUtilityImpl();


            // AddressBook Menu 
            // Add new Book , Select Existing Book , Exit program
            while (true)
            {
                Console.WriteLine("\n===========================");
                Console.WriteLine("1: Add New Address Book");
                Console.WriteLine("2: Select Address Book");
                Console.WriteLine("3: Search Based on City Or State");
                Console.WriteLine("4: Exit Address Book System\n");

                Console.Write("Enter Your Choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("===========================\n");

                switch (ch)
                {
                    case 1 : addressBookUtility.AddNewAddressBook();
                            break;
                    case 2 : 
                            AddressBook selectedBook = addressBookUtility.SelectAddressBook();
                            if(selectedBook!=null) ContactMenu(selectedBook);
                            break;
                    case 3 : addressBookUtility.SearchByCityOrState();
                            break;
                    case 4 : Console.WriteLine("Exiting Address Book System...\n");
                            return;
                    default : break;
                }
            }

        }

        private void ContactMenu(AddressBook addressBook)
        {
            contactUtility = new ContactUtilityImpl(addressBook,(AddressBookUtilityImpl)addressBookUtility);

            // Contact Menu
            // Add New Contact, Edit Contact By Name, Delete Contact By Name , Back To Address Book Menu
            
            while (true)
            {
                Console.WriteLine("\n===========================");
                Console.WriteLine("1: Add New Contact");
                Console.WriteLine("2: Edit Contact");
                Console.WriteLine("3: Delete Contact");
                Console.WriteLine("4: Back\n");

                Console.Write("Enter Choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("===========================\n");
                switch (ch)
                {
                    case 1 : contactUtility.AddNewContact();
                            break;
                    case 2 : contactUtility.EditContact();
                            break;
                    case 3 : contactUtility.DeleteContact();
                            break;
                    case 4 : Console.WriteLine("Returning to Address Book Menu ... \n");
                                return;
                    default : break;
                }
            }
        }

    }
}