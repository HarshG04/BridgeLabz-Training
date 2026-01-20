using System;

namespace SmartWarehouseManagementSystem
{
    class WarehouseUtility
    {
        private Storage<Electronics> electronicsStorage = new Storage<Electronics>();
        private Storage<Groceries> groceriesStorage = new Storage<Groceries>();
        private Storage<Furniture> furnitureStorage = new Storage<Furniture>();


        public void AddElectronics()
        {
            Electronics e = new Electronics();

            Console.Write("Enter Name: ");
            e.Name = Console.ReadLine();

            Console.Write("Enter Brand: ");
            e.Brand = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            e.Quantity = Convert.ToInt32(Console.ReadLine());

            electronicsStorage.AddItem(e);
            Console.WriteLine("Electronics item added.");
        }

        public void AddGroceries()
        {
            Groceries g = new Groceries();

            Console.Write("Enter Name: ");
            g.Name = Console.ReadLine();

            Console.Write("Enter Expiry Date: ");
            g.ExpiryDate = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            g.Quantity = Convert.ToInt32(Console.ReadLine());

            groceriesStorage.AddItem(g);
            Console.WriteLine("Groceries item added.");
        }

        public void AddFurniture()
        {
            Furniture f = new Furniture();

            Console.Write("Enter Name: ");
            f.Name = Console.ReadLine();

            Console.Write("Enter Material: ");
            f.Material = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            f.Quantity = Convert.ToInt32(Console.ReadLine());

            furnitureStorage.AddItem(f);
            Console.WriteLine("Furniture item added.");
        }


        public void ViewElectronics()
        {
            electronicsStorage.DisplayItems();
        }

        public void ViewGroceries()
        {
            groceriesStorage.DisplayItems();
        }

        public void ViewFurniture()
        {
            furnitureStorage.DisplayItems();
        }
    }
}
