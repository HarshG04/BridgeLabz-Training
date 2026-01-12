class RodMenu
{
    RodUtilityImpl utility;

    public void Menu()
    {
        utility = new RodUtilityImpl();

        while (true)
        {
            Console.WriteLine("1. Enter Price Chart");
            Console.WriteLine("2. Scenario A");
            Console.WriteLine("3. Scenario B");
            Console.WriteLine("4. Scenario C");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Choise: ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1 : utility.AddPriceChart();
                    break;
                case 2 : utility.ScenarioA();
                    break;
                case 3 : utility.ScenarioB();
                    break;
                case 4 : utility.ScenarioC();
                    break;
                case 5 : return;
                default : break;
            }
        }
    }
}