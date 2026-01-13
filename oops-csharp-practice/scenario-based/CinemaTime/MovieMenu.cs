class MovieMenu
{
    IMovie utility;

    public void Start()
    {
        utility = new MovieUtilityimpl();

        while(true){
            Console.WriteLine("\n===== Cinema Time Menu =====");
            Console.WriteLine("1: Add Movie");
            Console.WriteLine("2: Search Movie");
            Console.WriteLine("3: Display All Movies");
            Console.WriteLine("4: Exit");

            Console.Write("\nEnter Option: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1 : utility.AddMovie();
                        break;
                case 2 : utility.SearchMovie();
                        break;
                case 3 : utility.DisplayAllMovies();
                        break;
                case 4 : return;
                case 5 : break;
            }
        }
    }
}