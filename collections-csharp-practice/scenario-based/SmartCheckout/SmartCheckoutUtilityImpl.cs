namespace SmartCheckout
{
    class SmartCheckoutUtilityImpl : ISmartCheckout
    {

        class Item
        {
            private static int NextId = 1;
            public string ItemName{get;set;}
            public int price {get;set;}
            public int AvailableStock {get;set;}

            public Item()
            {
                ItemName = "I-"+NextId;
                NextId++;
            }
            public Item(string name)
            {
                ItemName = name;
            }

            public override string ToString()
            {
                return $"{ItemName}      |   {price}   |    {AvailableStock}";
            }
        }

        private Dictionary<string,Item> Items;
        private Queue<Customer> CustomerQueue;
        private static Random random;

        public SmartCheckoutUtilityImpl()
        {
            Items = new Dictionary<string, Item>();
            CustomerQueue = new Queue<Customer>();
            random = new Random();
        }

        public void AddItems()
        {
            Console.Write("Enter No of Items: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            for(int item = 1; item <= n; item++)
            {
                Item newItem = new Item();
                newItem.price = random.Next(50,500);
                newItem.AvailableStock = random.Next(1,50);

                Items[newItem.ItemName] = newItem;
            }

            Console.WriteLine("All Items Saved Successfully");
        }

        public void ShowItems()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Inventory Is Empty ... ");
                return;
            }

            Console.WriteLine("====== Inventory ======\n");

            Console.WriteLine("Item Name    Price   Quantity");

            foreach(string key in Items.Keys)
            {
                Console.WriteLine(Items[key]);
            }
        }

        public void UpdateStock()
        {
            Console.Write("Enter Item Name [I-Id]: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter Quantity To Add: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            

            if (!Items.ContainsKey(itemName))
            {
                Item newItem = new Item(itemName);
                newItem.price = random.Next(50,500);
                Items[newItem.ItemName] = newItem;
            }

            Items[itemName].AvailableStock += quantity;


            Console.WriteLine("\n"+Items[itemName]);
            Console.WriteLine("Item Stock Updated Successfully");
        }

        public void AddCustomer()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Inventory Is Empty ... ");
                return;
            }
            Console.Write("Enter No Of Required Items: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Customer newCustomer  = new Customer();
            
            // creating a random list of items
            for(int i = 0; i < n; i++)
            {
                string itemName = "I-"+random.Next(1,Items.Count);
                newCustomer.CustomerItemList.Add(itemName);
            }

            CustomerQueue.Enqueue(newCustomer);
        }

        public void ServeCustomer()
        {
            if (CustomerQueue.Count == 0)
            {
                Console.WriteLine("Customer Queue Is Empty");
                return;
            }

            Customer customer = CustomerQueue.Dequeue();

            Console.WriteLine($"\n===== Serving Customer: {customer.CustomerId} =========");
            
            int billAmount = 0;

            foreach(string item in customer.CustomerItemList)
            {
                if (!Items.ContainsKey(item) || Items[item].AvailableStock == 0)
                {
                    Console.WriteLine($"{item} Is Not Available");
                }
                else
                {
                    Console.WriteLine(item + " : " + Items[item].price);
                    billAmount += Items[item].price;
                    Items[item].AvailableStock--;
                }
            }

            Console.WriteLine("Total Bill Amount: "+ billAmount);

            Console.WriteLine();

        }
    }
}