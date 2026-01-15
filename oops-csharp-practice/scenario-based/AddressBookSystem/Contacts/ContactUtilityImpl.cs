namespace AddressBookSystem
{
    class ContactUtilityImpl : IContact
    {

        // private reference for the address book utility
        private AddressBookUtilityImpl addressBookUtility;
        
        // private reference for the address book class
        private AddressBook currentAddressBook;


        // constructors to initialising the address book reference
        public ContactUtilityImpl(AddressBook addressBook,AddressBookUtilityImpl addressBookUtility)
        {
            currentAddressBook = addressBook;
            this.addressBookUtility = addressBookUtility;
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

            //checking if Person With Same Name Exists Or Not
            int foundIdx = SearchByName(newContact.FirstName, newContact.LastName);

            if(foundIdx!=-1){
                Console.WriteLine("Person Already Exists");
                return;
            }

            
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

            bool isSaved = false;
            for(int i = 0; i < currentAddressBook.ContactIdx; i++)
            {   
                // if empty space has found save new contact information
                if (currentAddressBook.Contacts[i] == null)
                {
                    // Saving New Contact Details inside our contact Array
                    currentAddressBook.Contacts[i] = newContact;
                    currentAddressBook.StoredContacts++;
                    isSaved = true;
                    break;
                }
            }

            if(!isSaved)
            {
                // Saving New Contact Details At last available space
                currentAddressBook.Contacts[currentAddressBook.ContactIdx++] = newContact;
                currentAddressBook.StoredContacts++;
            }



            // saving that person inside personByCity and personByState Aswell
            // City
            string cityKey = newContact.City.ToLower();
            string stateKey = newContact.State.ToLower();
            if (!addressBookUtility.personByCity.ContainsKey(cityKey))
            {
                addressBookUtility.personByCity[cityKey] = new LinkedList<Contact>();
            }
            addressBookUtility.personByCity[cityKey].AddLast(newContact);

            // State
            if (!addressBookUtility.personByState.ContainsKey(stateKey))
            {
                addressBookUtility.personByState[stateKey] = new LinkedList<Contact>();
            }
            addressBookUtility.personByState[stateKey].AddLast(newContact);




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
            int foundIdx = SearchByName();
            if(foundIdx==-1) return;

            // Creating a Temp Object for Storing The Data
            Contact updatedContact = new Contact();

            Console.WriteLine("Enter New Details...");

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

            // saving oldContact
            Contact oldContact = currentAddressBook.Contacts[foundIdx];

            // Updating the Current Object With New Details
            currentAddressBook.Contacts[foundIdx] = updatedContact;

            // ---- Updating in Dictionary
            string oldCityKey = oldContact.City.ToLower();
            string oldStateKey = oldContact.State.ToLower();
            string newCityKey = updatedContact.City.ToLower();
            string newStateKey = updatedContact.State.ToLower();

            // remove old city entry
            if (addressBookUtility.personByCity.ContainsKey(oldCityKey))
            {
                addressBookUtility.personByCity[oldCityKey].Remove(oldContact);
                if (addressBookUtility.personByCity[oldCityKey].Count == 0)
                    addressBookUtility.personByCity.Remove(oldCityKey);
            }

            // remove old state entry
            if (addressBookUtility.personByState.ContainsKey(oldStateKey))
            {
                addressBookUtility.personByState[oldStateKey].Remove(oldContact);
                if (addressBookUtility.personByState[oldStateKey].Count == 0)
                    addressBookUtility.personByState.Remove(oldStateKey);
            }

            // add updated city entry
            if (!addressBookUtility.personByCity.ContainsKey(newCityKey))
            {
                addressBookUtility.personByCity[newCityKey] = new LinkedList<Contact>();
            }
            addressBookUtility.personByCity[newCityKey].AddLast(updatedContact);

            // add updated state entry
            if (!addressBookUtility.personByState.ContainsKey(newStateKey))
            {
                addressBookUtility.personByState[newStateKey] = new LinkedList<Contact>();
            }
            addressBookUtility.personByState[newStateKey].AddLast(updatedContact);

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
            int foundIdx = SearchByName();
            if(foundIdx==-1) return;

            // Confirmation For Deletion
            Console.WriteLine("Do You Want To DELETE Contact Information [y|n]");
            char choise = Console.ReadLine()[0];

            if (choise != 'y' && choise != 'Y')
            {
                Console.WriteLine("Contact Information Has Not Been Deleted");
                return;
            }

            // saving the referance of deleted contact 
            Contact deletedContact = currentAddressBook.Contacts[foundIdx];

            // Assigning The Current Object as Null
            currentAddressBook.Contacts[foundIdx] = null;
            if(foundIdx == currentAddressBook.ContactIdx-1) 
                currentAddressBook.ContactIdx--;
            currentAddressBook.StoredContacts--;

            // -------- UPDATE DICTIONARIES --------
            string cityKey = deletedContact.City.ToLower();
            string stateKey = deletedContact.State.ToLower();

            // remove from city dictionary
            if (addressBookUtility.personByCity.ContainsKey(cityKey))
            {
                addressBookUtility.personByCity[cityKey].Remove(deletedContact);
                if (addressBookUtility.personByCity[cityKey].Count == 0)
                    addressBookUtility.personByCity.Remove(cityKey);
            }

            // remove from state dictionary
            if (addressBookUtility.personByState.ContainsKey(stateKey))
            {
                addressBookUtility.personByState[stateKey].Remove(deletedContact);
                if (addressBookUtility.personByState[stateKey].Count == 0)
                    addressBookUtility.personByState.Remove(stateKey);
            }

            Console.WriteLine("Contact Has Been Deleted Successfully");
        }



        // Method For Search By Name and return the Correspondin Index Else -1 for no data found
        private int SearchByName()
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
            Console.WriteLine("Enter First and Last To Find... ");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            

            // calling SearchByName Method
            int foundIdx = SearchByName(firstName,lastName);

            if (foundIdx == -1)
            {
                Console.WriteLine("No Data found");
                return -1;
            }

            return foundIdx;
        }


        // Private Helper Method to Search By Name and Returning the Curresponing Index
        private int SearchByName(string firstName,string LastName)
        {
            // searching data in contacts array
            for(int i = 0; i < currentAddressBook.ContactIdx; i++)
            {
                if(currentAddressBook.Contacts[i] != null){

                    if(currentAddressBook.Contacts[i].FirstName.Equals(firstName,StringComparison.OrdinalIgnoreCase) && currentAddressBook.Contacts[i].LastName.Equals(LastName, StringComparison.OrdinalIgnoreCase))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
 

    }
}