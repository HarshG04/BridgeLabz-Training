namespace FitnessTracker
{
    class User
    {
        private static int NextId = 1;
        public string UserId {get;}
        public int StepsCount {get;set;}

        public User()
        {
            UserId = "U"+NextId;
            NextId++;
        }

        public override string ToString()
        {
            return $"{UserId} ---> {StepsCount}";
        }
    }
}