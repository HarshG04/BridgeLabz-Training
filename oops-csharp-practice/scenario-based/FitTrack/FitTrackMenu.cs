namespace FitTrack{

    class FitTrackMenu
    {
        private FitTrackUtility newTrack;

        public void FitMenu()
        {
            newTrack = new FitTrackUtility();

            Console.WriteLine("=== Welcome To Fit Track ====");
            newTrack.AddUser();
            Console.WriteLine("You can now Start Your Exercise\n");

            while (true)
            {
                Console.WriteLine("1: Check Burnt Calories For Cardio:");
                Console.WriteLine("2: Check Burnt Calories For Strength Workout:");
                Console.WriteLine("3: Stop Tracking");
                Console.Write("Enter choise: ");
                int option = Convert.ToInt32(Console.ReadLine());


                switch (option)
                {
                    case 1 : newTrack.TrackWorkout(newTrack.cardio);
                            break;
                    case 2 : newTrack.TrackWorkout(newTrack.strength);
                            break;
                    case 3 : return;
                    default : break;
                }
            }

        }
    }

}