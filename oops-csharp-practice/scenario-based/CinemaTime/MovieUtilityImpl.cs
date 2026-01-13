using System.Globalization;

class MovieUtilityimpl : IMovie
{

    private Movie[] movies;
    int idx = 0;

    public void AddMovie()
    {

        if (movies == null)
        {
            Console.Write("Please Enter The Capacity Of Movies: ");
            int cap = Convert.ToInt32(Console.ReadLine());
            movies = new Movie[cap];
        }

        if (idx >= movies.Length)
        {
            Console.WriteLine("Capacity Is Full LoL !!!");
            return;
        }

        Console.Write("Enter Movie title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Movie ShowTime: [HH:mm]: ");
        string time = Console.ReadLine();

        TimeOnly showTime = TimeOnly.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);

        Movie newMovie = new Movie();
        newMovie.MovieTitle = title;
        newMovie.ShowTime = showTime;

        movies[idx++] = newMovie;
        Console.WriteLine("Movie added successfully!");
        

    }

    public void SearchMovie()
    {
        if (idx == 0)
        {
            Console.WriteLine("No Movies In The DataBase LoL !!!");
            return;
        }
        Console.WriteLine("Search Any Movie....");
        Console.Write("Enter Movie Title or Keyword: \n");
        string Keyword = Console.ReadLine();

        bool isFound = false;
        for(int i = 0; i < idx; i++)
        {
            if (movies[i].MovieTitle.Contains(Keyword, StringComparison.OrdinalIgnoreCase))
            {
                ViewMovie(movies[i]);
                isFound = true;
            }
        }

        if(!isFound) Console.WriteLine("No Movie Found!!!!");

    }

    public void ViewMovie(Movie movie)
    {
        Console.WriteLine(movie);
    }

    public void DisplayAllMovies()
    {
        if (idx == 0)
        {
            Console.WriteLine("No Movies In The DataBase LoL !!!");
            return;
        }
        Console.WriteLine("Displayig All Movies!!!!\n");
        for(int i = 0; i < idx; i++)
        {
            Console.Write(i+1+": ");
            ViewMovie(movies[i]);
        }
    }

}