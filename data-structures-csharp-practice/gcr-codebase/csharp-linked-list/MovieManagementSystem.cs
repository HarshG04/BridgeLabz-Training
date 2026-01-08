using System;
class Movie
{
    public string title;
    public string director;
    public int year;
    public double rating;

    public Movie prev;
    public Movie next;

    public Movie(string title, string director, int year, double rating)
    {
        this.title = title;
        this.director = director;
        this.year = year;
        this.rating = rating;
        this.prev = null;
        this.next = null;
    }
}

class MovieList
{
    private Movie head;
    private Movie tail;

    public void AddMovie()
    {
        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Director: ");
        string director = Console.ReadLine();

        Console.Write("Enter Release Year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Rating: ");
        double rating = Convert.ToDouble(Console.ReadLine());

        Movie newMovie = new Movie(title, director, year, rating);

        if (head == null)
        {
            head = newMovie;
            tail = newMovie;
        }
        else
        {
            tail.next = newMovie;
            newMovie.prev = tail;
            tail = newMovie;
        }

        Console.WriteLine("Movie added.");
    }

    public void DeleteByTitle()
    {
        Console.Write("Enter Title to Delete: ");
        string title = Console.ReadLine();

        if (head == null)
        {
            Console.WriteLine("No records found.");
            return;
        }

        Movie temp = head;

        while (temp != null && temp.title != title)
            temp = temp.next;

        if (temp == null)
        {
            Console.WriteLine("Movie not found.");
            return;
        }

        if (temp == head) head = head.next;

        if (temp == tail) tail = tail.prev;

        if (temp.prev != null) temp.prev.next = temp.next;

        if (temp.next != null) temp.next.prev = temp.prev;

        Console.WriteLine("Movie deleted.");
    }

    public void Search()
    {
        Console.WriteLine("Search By:");
        Console.WriteLine("1. Director");
        Console.WriteLine("2. Rating");
        Console.Write("Enter choice: ");
        int ch = Convert.ToInt32(Console.ReadLine());

        Movie temp = head;
        bool found = false;

        if (ch == 1)
        {
            Console.Write("Enter Director Name: ");
            string dir = Console.ReadLine();

            while (temp != null)
            {
                if (temp.director == dir)
                {
                    Console.WriteLine($"{temp.title} | {temp.director} | {temp.year} | {temp.rating}");
                    found = true;
                }
                temp = temp.next;
            }
        }
        else
        {
            Console.Write("Enter Rating: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            while (temp != null)
            {
                if (temp.rating == rate)
                {
                    Console.WriteLine($"{temp.title} | {temp.director} | {temp.year} | {temp.rating}");
                    found = true;
                }
                temp = temp.next;
            }
        }

        if (!found) Console.WriteLine("No matching records.");
    }

    public void DisplayAll()
    {
        if (head == null)
        {
            Console.WriteLine("No movies found.");
            return;
        }

        Console.WriteLine("\nMovies :");
        Movie temp = head;

        while (temp != null)
        {
            Console.WriteLine($"{temp.title} | {temp.director} | {temp.year} | {temp.rating}");
            temp = temp.next;
        }
    }


    public void UpdateRating()
    {
        Console.Write("Enter Movie Title: ");
        string title = Console.ReadLine();

        Movie temp = head;

        while (temp != null)
        {
            if (temp.title == title)
            {
                Console.Write("Enter New Rating: ");
                temp.rating = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Rating updated.");
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Movie not found.");
    }
}

class Program
{
    static void Main()
    {
        MovieList movies = new MovieList();

        while (true)
        {
            Console.WriteLine("\n===== MOVIE MENU =====");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Delete by Title");
            Console.WriteLine("3. Search Movie");
            Console.WriteLine("4. Display All Movies");
            Console.WriteLine("5. Update Rating");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");

            int ch = Convert.ToInt32(Console.ReadLine());
            switch (ch)
            {
                case 1: movies.AddMovie(); break;
                case 2: movies.DeleteByTitle(); break;
                case 3: movies.Search(); break;
                case 4: movies.DisplayAll(); break;
                case 5: movies.UpdateRating(); break;
                case 6: return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
