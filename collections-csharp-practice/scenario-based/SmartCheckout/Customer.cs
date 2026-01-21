namespace SmartCheckout
{
    class Customer
    {
        private static int NextId = 101;
        public string CustomerId {get;}
        public List<string> CustomerItemList{get;set;}

        public Customer()
        {
            CustomerItemList = new List<string>();
            CustomerId = "C-"+NextId;
            NextId++;
        }
    }
}