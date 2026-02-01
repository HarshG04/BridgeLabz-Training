namespace FutureLogistics;

class UserInterface
{
    private ILogistic utility;

    public UserInterface()
    {
        utility = new LogisticUtility();
    }

    public void FutureLogisticsMenu()
    {
        while(true){
            Console.WriteLine("\n====== Future Logistics ========");
            Console.WriteLine("1. Enter New Goods Transport");
            Console.WriteLine("2. Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (ch)
            {
                case 1 : utility.CreateNewTransport(); break;
                case 2 : return;
                default : break;
            }
        }
        
    }
}