namespace FitTrack{

    abstract class WorkOut : ITrackable
    {
        public string WorkOutName{get;set;}
        public int BurnCaloriesPerHour{get;set;}

        public int CalculateCalories(int hrs)
        {
            return hrs * BurnCaloriesPerHour;
        }
    }
}