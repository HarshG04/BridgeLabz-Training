namespace BookShelf
{
    class BookShelfMenu()
    {
        private ILibrary utility;

        public void Start()
        {
            utility = new LibraryUtilityImpl();

            while (true)
            {
                Console.WriteLine("\n==== Book Shelf Menu ====");

                Console.WriteLine("1: Add New Book");
                Console.WriteLine("2: Borrow Book");
                Console.WriteLine("3: Return Book");
                // Console.WriteLine("4: Delete Book");
                Console.WriteLine("4: Exit");

                Console.Write("Enter Choise: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1 : utility.AddNewBook(); break;
                    case 2 : utility.BorrowBook(); break;
                    case 3 : utility.ReturnBook(); break;
                    // case 4 : utility.DeleteBook(); break;
                    case 4 : return;
                    default : break;
                }
            }
        }
    }
}