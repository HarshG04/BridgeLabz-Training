namespace AddressBookSystem
{
    class ContactUtilityImpl : IContact
    {

        // Creating a private object of My Contact Person
        private Contact ContactPerson;


        // Method For Adding a New Contact
        public void AddNewContact()
        {
            // Creating a Temp Object for Storing The Data
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


        //Edit Existing Person based on name
        public void EditContact()
        {
            // checking if any user information exists or not
            if (ContactPerson == null)
            {
                Console.WriteLine("No Active Contact Details Has Found!!");
                return;
            }

            Console.Write("Enter Person First Name: ");
            string name = Console.ReadLine();

            // checking the user given name with saved name
            if (!ContactPerson.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Name Not Found");
                return;
            }

            // Creating a Temp Object for Storing The Data
            Contact updatedContact = new Contact();

            Console.WriteLine("Enter New Details...");

            // Getting New Details From User
            Console.Write("Enter First Name: ");
            updatedContact.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            updatedContact.LastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            updatedContact.Address = Console.ReadLine();
            Console.Write("Enter City: ");
            updatedContact.City = Console.ReadLine();
            Console.Write("Enter State: ");
            updatedContact.State = Console.ReadLine();
            Console.Write("Enter ZIP Code: ");
            updatedContact.ZIP = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            updatedContact.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Email Id: ");
            updatedContact.Email = Console.ReadLine();


            // Updating the Current Object With New Details
            ContactPerson = updatedContact;

            Console.WriteLine("User Contact Information Has Been Updated!!");

        }

        //Delete Existing Person based on name
        public void DeleteContact()
        {
            // checking if any user information exists or not
            if (ContactPerson == null)
            {
                Console.WriteLine("No Active Contact Details Has Found!!");
                return;
            }

            Console.Write("Enter Person First Name: ");
            string name = Console.ReadLine();

            // checking the user given name with saved name
            if (!ContactPerson.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Name Not Found");
                return;
            }

            // Confirmation For Deletion
            Console.WriteLine("Do You Want To DELETE Contact Information [y|n]");
            char choise = Console.ReadLine()[0];

            if(choise!='y')
            {
                Console.WriteLine("Contact Information Has Not Been Deleted");
                return;
            }


            // Assigning The Current Object as Null
            ContactPerson = null;
            Console.WriteLine("Contact Has Been Deleted Successfully");
        }


    }
}