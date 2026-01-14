namespace AddressBookSystem
{
    class AddressBookMenu
    {   

        // Creating a private Reference Of IContact Interface
        private IContact utility;
        public void Start()
        {
            Console.WriteLine("Welcome To Address Book Program!!");

            // Initializing Interface Reference With ContactUtilityImpl class
            utility = new ContactUtilityImpl();

            while (true)
            {
                Console.WriteLine("\n1: Add New Contact");
                Console.WriteLine("2: Edit Contact");
                Console.WriteLine("3: Delete Contact");
                Console.WriteLine("4: Exit");
                Console.Write("Enter Choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (ch)
                {
                    case 1 : utility.AddNewContact();
                            break;
                    case 2 : utility.EditContact();
                            break;
                    case 3 : utility.DeleteContact();
                            break;
                    case 4 : Console.WriteLine("Exiting AddressBook ... ");
                                return;
                    default : break;
                }
            }

        }
    }
}