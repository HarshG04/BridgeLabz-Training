namespace AeroVigil;

class UserIterface
{
    private IFlight utility;

    public UserIterface()
    {
        utility = new FlightUtil();
    }

    public void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("\n====== Aero Vigil =======");
            Console.WriteLine("1. Enter Flight Details");
            Console.WriteLine("2. Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1 : utility.EnterFlighDetailsAndValide(); break;
                case 2 : return;
                default : break;
            }
        }
    }
}