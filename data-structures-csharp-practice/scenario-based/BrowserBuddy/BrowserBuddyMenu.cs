namespace BrowserBuddy
{
    class BrowserBuddyMenu
    {
        private IBrowserBuddy utility;

        public void Start(){
            
            utility = new BrowserBuddyUtilityImpl();

            while (true)
            {
                Console.WriteLine("\n=== Welcome To Browser Buddy === ");
                Console.WriteLine("1: Open New Tab");
                Console.WriteLine("2: Back");
                Console.WriteLine("3: Forward");
                Console.WriteLine("4: Close Tab");
                Console.WriteLine("5: Reopen Tab");
                Console.WriteLine("6: Exit\n");

                Console.Write("Enter Choise: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1 : utility.OpenNewTab();
                            break;
                    case 2 : utility.BackTab();
                            break;
                    case 3 : utility.ForwardTab();
                            break;
                    case 4 : utility.CloseTab();
                            break;
                    case 5 : utility.OpenLastClosedTab();
                            break;
                    case 6 : return;
                    default : break;
                }
            }
        }

    }
}