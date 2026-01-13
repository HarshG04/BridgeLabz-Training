class BookUtilityImpl : IBook
{
    private Book[] books;
    private int idx;

    public void AddBook()
    {
        if (books == null)
        {
            Console.Write("Please Enter The Capacity first: ");
            int cap = Convert.ToInt32(Console.ReadLine());
            books = new Book[cap];
        }

        if (idx >= books.Length)
        {
            Console.WriteLine("DataBase Is full!!!");
            return;
        }

        Book newBook = new Book();
        Console.WriteLine("Enter Book deatils: [Title - Author]");
        string[] bookDetails = Console.ReadLine().Split("-");
        newBook.BookTitle = bookDetails[0].Trim();
        newBook.BookAuther = bookDetails[1].Trim();

        books[idx++] = newBook;
        Console.WriteLine("New Book Added SuccessFully!!!");
    }

    public void SearchByAuthor()
    {
        if (idx == 0)
        {
            Console.WriteLine("Book DataBase Is Empty!!!");
            return;
        }

        Console.Write("Enter Author Name: ");
        string author = Console.ReadLine().ToLower();
        
        Console.WriteLine("Finding Book Details....\n");
        bool isFound = false;
        for(int i = 0; i < idx; i++)
        {
            if(books[i].BookAuther.Contains(author,StringComparison.OrdinalIgnoreCase))
            {
                ViewBook(books[i]);
                isFound = true;
            }
        }

        if(!isFound) Console.WriteLine("No Book Found!!!");
    }

    private void ViewBook(Book book)
    {
       Console.WriteLine("-> " + book);
    }

    public void SortBooksAlphabetically(){
		if(idx==0){
			Console.WriteLine("Book DataBase Is Empty!!!");
			return;
		}

        Console.WriteLine("Sorting By Alphabetically WRT Title....");
		
		for(int i=0;i<idx-1;i++){
		
			bool isSort = true;
			for(int j=0;j<idx-1;j++){
				if(CompareString(books[j].BookTitle,books[j+1].BookTitle)){
					Book temp = books[j];
					books[j] = books[j+1];
					books[j+1] = temp; 
					isSort = false;
				}
				
			}
			if(isSort) break;
		}

        Console.WriteLine("Sorting Complete!!!");
		
	}
	
	private bool CompareString(string a,string b)
	{
		// a>b true
		// else false

		int len = Math.Min(a.Length,b.Length);
		int i=0;
		while (i < len)
		{
			if (a[i] > b[i]) return true;
        	if (a[i] < b[i]) return false;
            i++;
		}

		if(a.Length>b.Length) return true;
		else return false;
	}

    public void DisplayAllBooks()
    {
        if (idx == 0)
        {
            Console.WriteLine("Book DataBase Is Empty!!!");
            return;
        }

        Console.WriteLine("Displayig All Books!!!!\n");
        for(int i = 0; i < idx; i++)
        {
            Console.Write(i+1+": ");
            ViewBook(books[i]);
        }
    }
}