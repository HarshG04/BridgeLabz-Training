namespace AddressBookSystem
{
    class ContactUtilityImpl : IContact
    {

        // Creating a private object of My Contact Person
        private Contact ContactPerson;


        // Method For Adding a New Contact
        public void AddNewContact()
        {
            Contact newContact = new Contact();

            Console.Write("Enter First Name: ");
            newContact.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            newContact.LastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            newContact.Address = Console.ReadLine();
            Console.Write("Enter City: ");
            newContact.City = Console.ReadLine();
            Console.Write("Enter State: ");
            newContact.State = Console.ReadLine();
            Console.Write("Enter ZIP Code: ");
            newContact.ZIP = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            newContact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Email Id: ");
            newContact.Email = Console.ReadLine();

            // Saving new contact details from temp object
            ContactPerson = newContact;
            Console.WriteLine("New Person's Contact Saved Successfully\n");

        }


    }
}