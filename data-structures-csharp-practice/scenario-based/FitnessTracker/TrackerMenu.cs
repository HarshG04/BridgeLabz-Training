namespace  FitnessTracker
{
    class TrackerMenu()
    {
        private ITracker utility;

        public void Start()
        {
            utility = new TrackerUtilityImpl();

            while(true)
            {
                Console.WriteLine("\n=============================");
                Console.WriteLine("1: Add New User");
                Console.WriteLine("2: Show LeaderBoard");
                Console.WriteLine("3: Update Leader Board");
                Console.WriteLine("4: Exit");

                Console.Write("Enter choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (ch)
                {
                    case 1 : utility.AddUser(); break;
                    case 2 : utility.ShowLeaderBoard(); break;
                    case 3 : utility.UpdateLeaderBoard(); break;
                    case 4 : return;
                    default : break;
                }
            }
        }
    }
}