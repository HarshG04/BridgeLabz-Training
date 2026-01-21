using System;

namespace SmartCheckout
{
    class SmartCheckoutMenu
    {
        private ISmartCheckout utility;

        public SmartCheckoutMenu()
        {
            utility = new SmartCheckoutUtilityImpl();
        }

        public void ShowMenu()
        {
            

            while(true)
            {
                Console.WriteLine("\n===== SMART CHECKOUT MENU =====");
                Console.WriteLine("1. Add Items");
                Console.WriteLine("2. Show Items");
                Console.WriteLine("3. Update Stock");
                Console.WriteLine("4. Add Customer");
                Console.WriteLine("5. Serve Customer");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: utility.AddItems(); break;

                    case 2: utility.ShowItems(); break;

                    case 3: utility.UpdateStock(); break;

                    case 4: utility.AddCustomer(); break;

                    case 5: utility.ServeCustomer(); break;

                    case 6: return;

                    default: break;
                }

            }
        }
    }
}
