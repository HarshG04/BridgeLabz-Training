using System;

class Item
{
    public int itemId;
    public string itemName;
    public int quantity;
    public double price;

    public Item next;

    public Item(int id, string name, int quantity, double price)
    {
        this.itemId = id;
        this.itemName = name;
        this.quantity = quantity;
        this.price = price;
        this.next = null;
    }
}

class Inventory
{
    private Item head;
    private Item tail;

    public void AddItem()
    {
        Console.Write("Enter Item ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Item Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Item newItem = new Item(id, name, qty, price);

        if (head == null)
        {
            head = tail = newItem;
        }
        else
        {
            tail.next = newItem;
            tail = newItem;
        }

        Console.WriteLine("Item Added Successfully.");
    }

    public void RemoveItem()
    {
        if (head == null)
        {
            Console.WriteLine("No items in inventory.");
            return;
        }

        Console.Write("Enter Item ID to Remove: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (head.itemId == id)
        {
            head = head.next;
            if (head == null) tail = null;
            Console.WriteLine("Item Removed.");
            return;
        }

        Item temp = head;

        while (temp.next != null && temp.next.itemId != id)
            temp = temp.next;

        if (temp.next == null)
        {
            Console.WriteLine("Item not found.");
            return;
        }

        temp.next = temp.next.next;

        if (temp.next == null)
            tail = temp;

        Console.WriteLine("Item Removed.");
    }

    public void UpdateQuantity()
    {
        Console.Write("Enter Item ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Item temp = head;

        while (temp != null)
        {
            if (temp.itemId == id)
            {
                Console.Write("Enter New Quantity: ");
                temp.quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Quantity Updated.");
                return;
            }

            temp = temp.next;
        }

        Console.WriteLine("Item Not Found.");
    }

    public void SearchItem()
    {
        Console.Write("Search By (1 = ID, 2 = Name): ");
        int op = Convert.ToInt32(Console.ReadLine());

        Item temp = head;
        bool found = false;

        if (op == 1)
        {
            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            while (temp != null)
            {
                if (temp.itemId == id)
                {
                    PrintItem(temp);
                    found = true;
                    break;
                }
                temp = temp.next;
            }
        }
        else
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            while (temp != null)
            {
                if (temp.itemName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    PrintItem(temp);
                    found = true;
                }
                temp = temp.next;
            }
        }

        if (!found) Console.WriteLine("Item Not Found.");
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No items available.");
            return;
        }

        Item temp = head;

        Console.WriteLine("\n===== INVENTORY =====");
        while (temp != null)
        {
            PrintItem(temp);
            temp = temp.next;
        }
    }

    private void PrintItem(Item i)
    {
        Console.WriteLine($"ID:{i.itemId} | Name:{i.itemName} | Qty:{i.quantity} | Price:{i.price}");
    }

    public void CalculateTotalValue()
    {
        double total = 0;
        Item temp = head;

        while (temp != null)
        {
            total += temp.price * temp.quantity;
            temp = temp.next;
        }

        Console.WriteLine($"\nTotal Inventory Value = {total}");
    }
}

class Program
{
    static void Main()
    {
        Inventory inv = new Inventory();

        while (true)
        {
            Console.WriteLine("\n===== INVENTORY MENU =====");
            Console.WriteLine("1. Add Item");
            Console.WriteLine("2. Remove Item");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Search Item");
            Console.WriteLine("5. Display All");
            Console.WriteLine("6. Total Inventory Value");
            Console.WriteLine("7. Exit");
            Console.Write("Enter Choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1: inv.AddItem(); break;
                case 2: inv.RemoveItem(); break;
                case 3: inv.UpdateQuantity(); break;
                case 4: inv.SearchItem(); break;
                case 5: inv.DisplayAll(); break;
                case 6: inv.CalculateTotalValue(); break;
                case 7 : return;
                default: Console.WriteLine("Invalid Choice."); break;
            }
        }
    }
}
