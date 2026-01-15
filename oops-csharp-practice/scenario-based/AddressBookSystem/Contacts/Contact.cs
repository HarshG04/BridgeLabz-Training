namespace AddressBookSystem
{
    class Contact
    {
        // UC - 1 Creating The Contact Class With Some Fields
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Address{get;set;}
        public string City {get;set;}
        public string State {get;set;}
        public int ZIP {get;set;}
        public long PhoneNumber {get;set;}
        public string Email {get;set;}


        public override string ToString()
        {
            return $"{FirstName} {LastName} || {Address}, {City}, {State}, {ZIP} || {PhoneNumber}, {Email}";
        }


    }

}