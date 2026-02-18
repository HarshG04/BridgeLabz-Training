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

        // Method For Adding a New Contact
        // Refactoring Method Accoring To the contacts Array
        public void AddNewContact()
        {
            try
            {
                
                // Creating a Temp Object for Storing The Data
                Contact newContact = new Contact();

                Console.Write("Enter First Name: ");
                newContact.FirstName = Console.ReadLine();
                Console.Write("Enter Last Name: ");
                newContact.LastName = Console.ReadLine();

                //checking if Person With Same Name Exists Or Not
                int foundIdx = SearchByName(newContact.FirstName, newContact.LastName);

                if(foundIdx!=-1){
                    throw new InvalidContactException("\nPerson Already Exists");
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
                Console.WriteLine();

                currentAddressBook.Contacts.Add(newContact);



                // saving that person inside personByCity and personByState Aswell
                // City
                string cityKey = newContact.City.ToLower();
                string stateKey = newContact.State.ToLower();
                if (!addressBookUtility.personByCity.ContainsKey(cityKey))
                {
                    addressBookUtility.personByCity[cityKey] = new List<Contact>();
                }
                addressBookUtility.personByCity[cityKey].Add(newContact);

                // State
                if (!addressBookUtility.personByState.ContainsKey(stateKey))
                {
                    addressBookUtility.personByState[stateKey] = new List<Contact>();
                }
                addressBookUtility.personByState[stateKey].Add(newContact);


                // displaying newly added data
                Console.WriteLine(newContact);
                Console.WriteLine("New Person's Contact Saved Successfully\n");
            }
            catch(InvalidContactException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }


        }



        //Edit Existing Person based on name
        public void EditContact()
        {
            try
            {
                
                // checking if we have any data
                if (currentAddressBook.Contacts.Count == 0)
                {
                    throw new InvalidAddressBookException("Address Book Is Empty...");
                }

                // checking the user given name with saved name
                int foundIdx = SearchByName();
                if(foundIdx==-1) return;

                // Creating a Temp Object for Storing The Data
                Contact updatedContact = new Contact();

                Console.WriteLine("Enter New Details...");

                // Console.Write("Enter First Name: ");
                // updatedContact.FirstName = Console.ReadLine();
                // Console.Write("Enter Last Name: ");
                // updatedContact.LastName = Console.ReadLine();

                // assigning name as it is
                updatedContact.FirstName = currentAddressBook.Contacts[foundIdx].FirstName;
                updatedContact.LastName = currentAddressBook.Contacts[foundIdx].LastName;

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
                    addressBookUtility.personByCity[newCityKey] = new List<Contact>();
                }
                addressBookUtility.personByCity[newCityKey].Add(updatedContact);

                // add updated state entry
                if (!addressBookUtility.personByState.ContainsKey(newStateKey))
                {
                    addressBookUtility.personByState[newStateKey] = new List<Contact>();
                }
                addressBookUtility.personByState[newStateKey].Add(updatedContact);


                // displaying updated data
                Console.WriteLine(currentAddressBook.Contacts[foundIdx]);
                Console.WriteLine("User Contact Information Has Been Updated!!");
            }
            catch(InvalidAddressBookException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(InvalidContactException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
        }


        //Delete Existing Person based on name
        public void DeleteContact()
        {
            try
            {
                
                // checking if we have any data
                if (currentAddressBook.Contacts.Count == 0)
                {
                    throw new InvalidAddressBookException("Address Book Is Empty...");
                }

                // checking the user given name with saved name
                int foundIdx = SearchByName();
                if(foundIdx==-1) return;

                // Confirmation For Deletion
                // displaying user data
                Console.WriteLine(currentAddressBook.Contacts[foundIdx]);
                Console.Write("Do You Want To DELETE Contact Information [y|n]: ");
                char choise = Console.ReadLine()[0];

                if (choise != 'y' && choise != 'Y')
                {
                    Console.WriteLine("Contact Information Has Not Been Deleted");
                    return;
                }

                // saving the referance of deleted contact 
                Contact deletedContact = currentAddressBook.Contacts[foundIdx];

                currentAddressBook.Contacts.RemoveAt(foundIdx);   // deleting data
                
                // updating dictionaried personBy City and State
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
            catch(InvalidAddressBookException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(InvalidContactException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
        }



        // Method For Search By Name and return the Correspondin Index Else -1 for no data found
        private int SearchByName()
        {
                // checking if we have any data
                if (currentAddressBook.Contacts.Count == 0)
                {
                    Console.WriteLine("Address Book Is Empty...");
                    return -1;
                } 

                // getting name from user to search
                Console.WriteLine("Enter First and Last To Find... ");
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                

                // calling SearchByName Method
                int foundIdx = SearchByName(firstName,lastName);

                if (foundIdx == -1)
                {
                    throw new InvalidContactException("\nNo Data found For This Name");
                    // return -1;
                }

                return foundIdx;
        }


        // Private Helper Method to Search By Name and Returning the Curresponing Index
        private int SearchByName(string firstName,string lastName)
        {
            // searching data in contacts array
            for(int i=0;i<currentAddressBook.Contacts.Count;i++)
            {   
                Contact contact = currentAddressBook.Contacts[i];
                string fullName = $"{contact.FirstName} {contact.LastName}";
                if(fullName.Equals($"{firstName} {lastName}")) return i;
            }

            return -1;
        }


        // Method for sorting the contacts data lexographically based on name
        public void SortByNameAndDisplay()
        {
            try
            {      
                // Checking Empty Array
                if (currentAddressBook.Contacts.Count == 0)
                {
                    throw new InvalidAddressBookException("Address Book Data is Empty...");
                }

                List<Contact> tempContacts = new List<Contact>(currentAddressBook.Contacts);

                tempContacts.Sort((x,y)=>string.Compare($"{x.FirstName} {x.LastName}",$"{y.FirstName} {y.LastName}"));

                Console.WriteLine("Contacts sorted successfully by name. Printing Sorted Data ... \n");

                foreach(Contact contact in tempContacts)
                {
                    Console.WriteLine(contact);
                }
            }
            catch(InvalidAddressBookException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(InvalidContactException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
        }

        public void SortByCityStateZip()
        {
            try
            {
                // Checking Empty Array
                if (currentAddressBook.Contacts.Count == 0)
                {
                    throw new InvalidAddressBookException("Address Book Contacts Data is Empty...");
                }
                while(true)
                {
                    Console.Write("Please Enter Your Sorting Preference [1:City, 2:State, 3:ZIP, 4:NA]: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if(choice==4) return;

                    // creating temp array for storing and sorting data
                    List<Contact> tempContacts = new List<Contact>(currentAddressBook.Contacts);
                    switch (choice)
                    {
                        case 1 : tempContacts.Sort((x,y)=> string.Compare(x.City,y.City));
                                break;
                        case 2 : tempContacts.Sort((x,y)=> string.Compare(x.State,y.State));
                                break;
                        case 3 : tempContacts.Sort((x,y) => x.ZIP.CompareTo(y.ZIP));
                                break;
                        default : break;
                    }

                    foreach(Contact contact in tempContacts)
                    {
                        Console.WriteLine(contact);
                    }
                }
            }
            catch(InvalidAddressBookException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(InvalidContactException e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: "+ e.Message);
            }
            
        }
    }

}