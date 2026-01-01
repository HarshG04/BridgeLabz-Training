class CafeApp()
{
    // assumption : we have infinite supply of every item
    private string[] items;
    static int nextOrderId = 101;
    public void SetMenuItems()
    {
        items = new string[10];
        Console.WriteLine("Enter Todays 10 Menu items");
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = Console.ReadLine();
        }
    }

    public void DislpayMenuItems()
    {
        if (items == null)
        {
            Console.WriteLine("---No Menu Found---");
            return;
        }

        Console.WriteLine("-----TODAYS MENU------");
        for(int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"Id:{i+1} : {items[i]}");
        }
        Console.WriteLine();
    }

    public void TakeCustomerOrder()
    {
        DislpayMenuItems();
        int[,] costumerOrder = new int[10,2];

        Console.WriteLine("----Enter Item Id and Quantity-----");
        int idx = 0;
        while (true)
        {
            Console.Write("Enter item id or 0 : ");
            int id = Convert.ToInt32(Console.ReadLine());
            if(id==0)
            {
                Console.WriteLine("Your Order has placed sucessfully");
                break;
            }
            Console.Write("\nEnter Quantity : ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            
            costumerOrder[idx,0] = id-1;
            costumerOrder[idx,1] = quantity;
            idx++;
        }

        ShowCostumerOrder(costumerOrder,idx);

    }

    public void ShowCostumerOrder(int[,] order,int idx)
    {
        if(idx==0)
        {
            Console.WriteLine("--- No Order Found---");
            return;
        }
        Console.WriteLine($"\n---Your Order Id {nextOrderId++}----");
        Console.WriteLine("\n---ItemName : Quantity----");
        for(int i = 0; i < idx; i++)
        {
           Console.WriteLine($"{items[order[i,0]]} : {order[i,1]}"); 
        }
    }

}

class Program
{
    static void Main()
    {
        CafeApp cafe = new CafeApp();
        Console.WriteLine("Enter Todays Menu Items: ");
        cafe.SetMenuItems();
        while (true)
        {
            Console.WriteLine("\n\n1. Diaplay Todays Menu Items");
            Console.WriteLine("2. Place New Order");
            Console.WriteLine("3. Exit - Jaldi Vaha Se Niklo");
            Console.WriteLine();

            Console.Write("Enter Choice: ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1 : cafe.DislpayMenuItems();
                    break;
                case 2 : cafe.TakeCustomerOrder();
                    break;
                case 3 : return;
                default : break;
            }
        }
    }
}