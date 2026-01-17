namespace FlashDealz
{
    class ProductMenu()
    {
        private IProduct utility;

        public void Start()
        {
            utility = new ProductUtilityImpl();

            utility.AddProducts();

            while (true)
            {
                Console.WriteLine("1: Add Products: ");
                Console.WriteLine("2: Show All Products: ");
                Console.WriteLine("3: Sort All Products: ");
                Console.WriteLine("4: Exit ");
                Console.Write("Enter choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {   
                    case 1 : utility.AddProducts(); break;
                    case 2 : utility.ShowProducts(); break;
                    case 3 : utility.SortProducts(); break;
                    case 4 : return;
                    default : break;
                }
            }
        }
    }
}