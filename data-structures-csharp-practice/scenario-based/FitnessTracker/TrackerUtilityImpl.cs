namespace FitnessTracker
{
    class TrackerUtilityImpl : ITracker
    {
        private User[] users;
        private int maxCapacity = 20;
        private int currUsers;
        private Random random;

        public TrackerUtilityImpl()
        {
            users = new User[maxCapacity];
            random = new Random();
        }

        public void AddUser()
        {
            if(currUsers >= maxCapacity)
            {
                Console.WriteLine("Can't Add More Users: ");
                return;
            }

            User newUser = new User();
            users[currUsers++] = newUser;

            Console.WriteLine(newUser);
            Console.WriteLine($"\nNew User Added SuccesFully [{currUsers}/{maxCapacity}]");

        }

        public void UpdateLeaderBoard()
        {
            if (currUsers == 0)
            {
                Console.WriteLine("No Active Users");
                return;
            }
            for(int i = 0; i < currUsers; i++)
            {
                users[i].StepsCount += random.Next(50);
            }

            for(int i = 0; i < currUsers-1; i++)
            {
                for(int j=i+1;j<currUsers; j++)
                {
                    if (users[i].StepsCount < users[j].StepsCount)
                    {
                        User temp = users[i];
                        users[i] = users[j];
                        users[j] = temp;
                    }
                }

            }

            Console.WriteLine("Leader Board Updated Successfully");
        }

        public void ShowLeaderBoard()
        {
            if (currUsers == 0)
            {
                Console.WriteLine("No Active Users");
                return;
            }
            for(int i = 0; i < currUsers; i++)
            {
                Console.WriteLine(i+1+": "+users[i]);
            }
        }


    }
}