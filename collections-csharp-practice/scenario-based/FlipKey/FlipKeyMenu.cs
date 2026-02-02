namespace FlipKey;

class FlipKeyMenu
{
    FlipKeyUtility utility = new FlipKeyUtility();

    public void UserMenu()
    {
        while (true)
        {
            Console.WriteLine("======== Flip Key=========");
            Console.WriteLine("1: Enter New Input");
            Console.WriteLine("2: Exit");
            Console.Write("Enter Choice: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1 : utility.TakeInput();
                break;
                case 2 : return;
                default : break;
            }
        }
    }
}