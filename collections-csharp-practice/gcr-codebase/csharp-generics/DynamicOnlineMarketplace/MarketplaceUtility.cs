using System;
using System.Collections.Generic;

namespace DynamicOnlineMarketplace
{
    class MarketplaceUtility
    {
        private List<BaseProduct> catalog = new List<BaseProduct>();

        public void AddBook()
        {
            Product<BookCategory> book = new Product<BookCategory>();

            Console.Write("Enter Book Name: ");
            book.Name = Console.ReadLine();

            Console.Write("Enter Price: ");
            book.Price = Convert.ToDouble(Console.ReadLine());

            book.Category = new BookCategory();
            catalog.Add(book);

            Console.WriteLine("Book added successfully.");
        }

        public void AddClothing()
        {
            Product<ClothingCategory> cloth = new Product<ClothingCategory>();

            Console.Write("Enter Clothing Name: ");
            cloth.Name = Console.ReadLine();

            Console.Write("Enter Price: ");
            cloth.Price = Convert.ToDouble(Console.ReadLine());

            cloth.Category = new ClothingCategory();
            catalog.Add(cloth);

            Console.WriteLine("Clothing added successfully.");
        }

        public void ViewProducts()
        {
            if (catalog.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            foreach (var p in catalog)
                Console.WriteLine(p);
        }

        public void ApplyDiscount()
        {
            Console.Write("Enter discount percentage: ");
            double percent = Convert.ToDouble(Console.ReadLine());

            foreach (var p in catalog)
                DiscountUtility.ApplyDiscount(p, percent);

            Console.WriteLine("Discount applied.");
        }
    }
}
