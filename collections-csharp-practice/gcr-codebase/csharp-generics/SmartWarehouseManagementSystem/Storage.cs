using System;
using System.Collections.Generic;

namespace SmartWarehouseManagementSystem
{
    class Storage<T> where T : WarehouseItem
    {
        private List<T> items = new List<T>();

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void DisplayItems()
        {
            Console.WriteLine($"--- Displaying {typeof(T).Name} Items ---");
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        // Covariance example using IEnumerable<out T>
        public IEnumerable<T> GetItems()
        {
            return items;
        }
    }
}
