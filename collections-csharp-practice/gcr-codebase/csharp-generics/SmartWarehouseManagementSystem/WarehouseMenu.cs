using System;

namespace SmartWarehouseManagementSystem
{
    class WarehouseMenu
    {
        private WarehouseUtility utility;

        public WarehouseMenu()
        {
            utility = new WarehouseUtility();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Smart Warehouse Management ---");
                Console.WriteLine("1. Add Electronics");
                Console.WriteLine("2. Add Groceries");
                Console.WriteLine("3. Add Furniture");
                Console.WriteLine("4. Display Electronics");
                Console.WriteLine("5. Display Groceries");
                Console.WriteLine("6. Display Furniture");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        utility.AddElectronics();
                        break;
                    case 2:
                        utility.AddGroceries();
                        break;
                    case 3:
                        utility.AddFurniture();
                        break;
                    case 4:
                        utility.ViewElectronics();
                        break;
                    case 5:
                        utility.ViewGroceries();
                        break;
                    case 6:
                        utility.ViewFurniture();
                        break;
                    case 7: return;
                    default:
                        break;
                }
            }
        }
    }

}