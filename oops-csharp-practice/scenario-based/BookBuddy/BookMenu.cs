class BookMenu
{
    IBook utility;

    public void Start()
    {
        utility = new BookUtilityImpl();

        while(true){
            Console.WriteLine("\n===== BookBuddy - Digital Bookshelf App =====");
            Console.WriteLine("1: Add Book");
            Console.WriteLine("2: Search Book");
            Console.WriteLine("3: Sort Books Alphabatically");
            Console.WriteLine("4: Display All Books");
            Console.WriteLine("5: Exit");

            Console.Write("\nEnter Option: ");
            int ch = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("================");
            switch (ch)
            {
                case 1 : utility.AddBook();
                        break;
                case 2 : utility.SearchByAuthor();
                        break;
                case 3 : utility.SortBooksAlphabetically();
                        break;
                case 4 : utility.DisplayAllBooks();
                        break;
                case 5 : return;
                case 6 : break;
            }
        }
    }
}