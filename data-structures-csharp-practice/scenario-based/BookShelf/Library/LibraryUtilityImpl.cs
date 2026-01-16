namespace BookShelf
{
    class LibraryUtilityImpl : ILibrary
    {
        Dictionary<string,BookUtilityImpl> library;

        
        public LibraryUtilityImpl()
        {
            library = new Dictionary<string, BookUtilityImpl>();
        }

        public void AddNewBook()
        {
            Console.Write("Enter Gener Of book: ");
            string genre = Console.ReadLine().ToLower();

            if (!library.ContainsKey(genre))
            {
                library[genre.ToLower()] = new BookUtilityImpl();
            }

            library[genre].AddNewBook(genre);
        }

        public void BorrowBook()
        {
            if(library.Count == 0)
            {
                Console.WriteLine("Library Is Empty");
                return;
            }

            Console.Write("Enter Gener Of book: ");
            string genre = Console.ReadLine().ToLower();

            if (!library.ContainsKey(genre))
            {
                Console.WriteLine("Sorry This Gener Is Not Available");
                return;
            }

            library[genre].BorrowBook();

        }

        public void ReturnBook()
        {
            if(library.Count == 0)
            {
                Console.WriteLine("Library Is Empty");
                return;
            }

            Console.Write("Enter Gener Of book: ");
            string genre = Console.ReadLine().ToLower();

            if (!library.ContainsKey(genre))
            {
                Console.WriteLine("Sorry This Gener Is Not Available");
                return;
            }

            library[genre].ReturnBook();

        }
    }
}



