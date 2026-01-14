namespace AddressBookSystem
{
    class AddressBookMenu
    {
        private ContactUtilityImpl utility;
        public void Start()
        {
            Console.WriteLine("Welcome To Address Book Program!!");

            utility = new ContactUtilityImpl();

            while (true)
            {
                Console.WriteLine("1: Add New Contact");
                Console.WriteLine("2: Exit");
                Console.Write("Enter Choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1 : utility.AddNewContact();
                            break;
                    case 2 : Console.WriteLine("Exiting AddressBook ... ");
                                return;
                    default : break;
                }
                }

        }
    }
}