namespace FitTrack{
    
    class FitTrackUtility
    {
        private UserProfile user;
        
        public WorkOut cardio;
        public WorkOut strength;


        public void AddUser()
        {

            user = new UserProfile();

            Console.Write("Enter Name: ");
            user.UserName = Console.ReadLine();

            Console.Write("Enter Age: ");
            user.UserAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Height: ");
            user.UserHeight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Weight: ");
            user.UserWeight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"==User {user.UserName} Added Successfully!!==");

            cardio = new CardioWorkout();
            strength = new StrengthWorkout();
        } 

        public void TrackWorkout(WorkOut workout)
        {
            Console.Write("Enter workout hours: ");
            int hrs = Convert.ToInt32(Console.ReadLine());

            int calories = workout.CalculateCalories(hrs);

            Console.WriteLine($"{workout.WorkOutName} burned {calories} calories");
        }


    }

}