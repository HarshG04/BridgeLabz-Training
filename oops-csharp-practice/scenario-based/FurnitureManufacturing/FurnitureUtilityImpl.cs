class RodUtilityImpl : IRod
{
    Rod rod = new Rod();
    private int[,]  priceChart;

    public void AddPriceChart()
    {
        Console.Write("Enter No of Price Chart: ");
        int cap = Convert.ToInt32(Console.ReadLine());
        priceChart = new int[cap,2];

        Console.WriteLine("Enter Cut Length And Price :");
        for(int i = 0; i < cap; i++)
        {
            Console.Write($"Enter Cut{i+1} Length: ");
            priceChart[i,0] = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter Cut{i+1} Price: ");
            priceChart[i,1] = Convert.ToInt32(Console.ReadLine());            
        }

        Console.WriteLine("Price Chart Saved Successfully!!!");

    }

    public void ScenarioA()
    {
        if(priceChart==null)
        {
            Console.WriteLine("Enter Price Chart First!!!");
            return;
        }
        rod.Length = 12;
        
        int price = 0;
        int cut = 0;
        for(int i = 0; i < priceChart.GetLength(0); i++)
        {
           if(priceChart[i,0]<=rod.Length && priceChart[i,1]>price)
           {
                price = priceChart[i,1];
                cut = priceChart[i,0];
           }
        }

        Console.WriteLine($"Cut Length: {cut} || Price: {price}");
    
    
    }
    public void ScenarioB()
    {
        if(priceChart==null)
        {
            Console.WriteLine("Enter Price Chart First!!!");
            return;
        }
        Console.WriteLine("Enter Length: ");
        rod.Length = Convert.ToInt32(Console.ReadLine());
        
        int price = 0;
        int cut = 0;
        for(int i = 0; i < priceChart.GetLength(0); i++)
        {
           if(priceChart[i,0]<=rod.Length && priceChart[i,1]>price)
           {
                price = priceChart[i,1];
                cut = priceChart[i,0];
           }
        }

        Console.WriteLine($"Cut Length: {cut} || Price: {price} || Waste: {rod.Length-cut}");
    }

    public void ScenarioC()
    {
        if(priceChart==null)
        {
            Console.WriteLine("Enter Price Chart First!!!");
            return;
        }
        Console.WriteLine("Enter Length: ");
        rod.Length = Convert.ToInt32(Console.ReadLine());
        
        int price = 0;
        int cut = 0;
        for(int i = 0; i < priceChart.GetLength(0); i++)
        {
           if(priceChart[i,0]<=rod.Length && priceChart[i,1]>price)
           {
                price = priceChart[i,1];
                cut = priceChart[i,0];
           }
        }

        Console.WriteLine($"Cut Length: {cut} || Price: {price} || Waste: {rod.Length-cut}");
    }
}