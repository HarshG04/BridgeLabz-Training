namespace AddressBookSystem
{
    class ContactUtilityImpl : IContact
    {
        
        // private reference for the address book class
        private AddressBook currentAddressBook;

        // constructors to initialising the address book reference
        public ContactUtilityImpl(AddressBook addressBook)
        {
            currentAddressBook = addressBook;
        }


        // Implemented In AddressBookUtility UC-6
        
        // // Method for initialising contact array capacity by user
        // public void AddAddressBookCapacity()
        // {
        // }


        // Method For Adding a New Contact
        // Refactoring Method Accoring To the contacts Array
        public void AddNewContact()
        {
            // checking if contacts array has not been initialised
            if (currentAddressBook.Contacts == null)
            {
                Console.WriteLine("No Address Book Has Found");
                return;
            }

            // checking for if address book has reached it limit
            if (currentAddressBook.StoredContacts >= currentAddressBook.Contacts.Length)
            {
                Console.WriteLine("Address Book Capacity Has Reached. Can't Add More");
                return;
            }


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

            
            // checking for empty space in between our contacts array

            for(int i = 0; i < currentAddressBook.ContactIdx; i++)
            {   
                // if empty space has found save new contact information
                if (currentAddressBook.Contacts[i] == null)
                {
                    // Saving New Contact Details inside our contact Array
                    currentAddressBook.Contacts[i] = newContact;
                    currentAddressBook.StoredContacts++;
                    Console.WriteLine("New Person's Contact Saved Successfully\n");
                    return;
                }
            }

            // Saving New Contact Details At last available space
            currentAddressBook.Contacts[currentAddressBook.ContactIdx++] = newContact;
            currentAddressBook.StoredContacts++;
            Console.WriteLine("New Person's Contact Saved Successfully\n");
            

        }


        //Edit Existing Person based on name
        public void EditContact()
        {
            // checking if contacts array has not been initialised
            if (currentAddressBook.Contacts == null )
            {
                Console.WriteLine("No Address Book Has Found");
                return;
            }

            // checking if we have any data
            if (currentAddressBook.StoredContacts == 0)
            {
                Console.WriteLine("No Data Has Found");
                return;
            }


            // checking the user given name with saved name
            int foundIdx = SearchByFirstName();
            if(foundIdx==-1) return;

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
            currentAddressBook.Contacts[foundIdx] = updatedContact;
            Console.WriteLine("User Contact Information Has Been Updated!!");

        }

        //Delete Existing Person based on name
        public void DeleteContact()
        {
             // checking if contacts array has not been initialised
            if (currentAddressBook.Contacts == null)
            {
                Console.WriteLine("No Address Book Has Found");
                return;
            }
            // checking if we have any data
            if (currentAddressBook.StoredContacts == 0)
            {
                Console.WriteLine("No Data Has Found");
                return;
            }

            // checking the user given name with saved name
            int foundIdx = SearchByFirstName();
            if(foundIdx==-1) return;

            
            // Confirmation For Deletion
            Console.WriteLine("Do You Want To DELETE Contact Information [y|n]");
            char choise = Console.ReadLine()[0];

            if (choise != 'y' && choise != 'Y')
            {
                Console.WriteLine("Contact Information Has Not Been Deleted");
                return;
            }

            // Assigning The Current Object as Null
            currentAddressBook.Contacts[foundIdx] = null;
            if(foundIdx == currentAddressBook.ContactIdx-1) currentAddressBook.ContactIdx--;
            currentAddressBook.StoredContacts--;
            Console.WriteLine("Contact Has Been Deleted Successfully");
        }


        // Method For Search By First Name and return the Correspondin Index Else -1 for no data found
        private int SearchByFirstName()
        {
            // checking if contacts array has not been initialised
            if (currentAddressBook.Contacts == null)
            {
                Console.WriteLine("No Address Book Has Found");
                return -1;
            }  
            // checking if we have any data
            if (currentAddressBook.StoredContacts == 0)
            {
                Console.WriteLine("No Data Has Found");
                return -1;
            } 

            // getting first name from user to search
            Console.Write("Enter First Name To Find: ");
            string firstName = Console.ReadLine();

            // searching data in contacts array
            for(int i = 0; i < currentAddressBook.ContactIdx; i++)
            {
                if(currentAddressBook.Contacts[i] !=null && currentAddressBook.Contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }

            Console.WriteLine("No Data found");
            return -1;
        }

    }
}