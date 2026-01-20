using System;

namespace DynamicOnlineMarketplace
{
    class MarketplaceMenu
    {
        private MarketplaceUtility utility = new MarketplaceUtility();

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Dynamic Online Marketplace ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Clothing");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Apply Discount");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: utility.AddBook(); break;
                    case 2: utility.AddClothing(); break;
                    case 3: utility.ViewProducts(); break;
                    case 4: utility.ApplyDiscount(); break;
                    case 5: return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }
    }
}
