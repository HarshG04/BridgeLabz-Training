using System;
class LibraryManagementSystem
{
    private string[,] books;
    private int currBookIdx = 0;

    public void BookMenu()
    {
        SetLibrarySize();
        while (true)
        {
            Console.WriteLine("\n\n--------Book Menu---------");
            Console.WriteLine("1 : Add New Book");
            Console.WriteLine("2 : Search Book");
            Console.WriteLine("3 : Updatae Book Status");
            Console.WriteLine("4 : Display last Added Book");
            Console.WriteLine("Other : Exit Store");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1 : AddNewBook();
                break;
                case 2 : SearchBook();
                break;
                case 3 : UpdateBookStatus();
                break;
                case 4 : DisplayBook(currBookIdx-1);
                break;
                default : return;
            }
            
        }
        
    }

    private void SetLibrarySize()
    {
        Console.Write("enter the number of books you want to save : ");
        int size = Convert.ToInt32(Console.ReadLine());
        this.books = new string[size,3]; //0-title 1-auther 2-status
    }

    private void AddNewBook()
    {
        if (currBookIdx >= books.Length)
        {
            Console.WriteLine("---Database Is full---");
            return;
        }
        Console.WriteLine("Enter Book title, auther name");

        // string title = Console.ReadLine();
        // string autherName = Console.ReadLine();
        // books[currBookIdx,0] = title;
        // books[currBookIdx,1] = autherName;
        // books[currBookIdx,2] = "available";

        for(int i = 0; i < books.GetLength(1)-1; i++)
        {
            books[currBookIdx,i] = Console.ReadLine();
        }

        books[currBookIdx,books.GetLength(1)-1] = "available";

        currBookIdx++;

        Console.WriteLine("Your Book saved successfully");
    }

    // search using title
    private int SearchBook()
    {
        if (currBookIdx == 0)
        {
            Console.WriteLine("-----Library Is Empty--------");
            return -2;  // for library empty
        }

        Console.WriteLine("Enter title for searching: ");
        string str = Console.ReadLine().ToLower();
        for(int i = 0; i < currBookIdx; i++)
        {
            if (books[i,0].ToLower().Contains(str))
            {
                DisplayBook(i);
                return i;
            }
        }

        Console.WriteLine("\n---Book Not Found---");
        return -1;
    }

    private void DisplayBook(int bookIdx)
    {
        if (currBookIdx == 0 || bookIdx == -2)
        {
            Console.WriteLine("-----Library Is Empty--------");
        }

        if(bookIdx>currBookIdx || bookIdx >= books.Length || bookIdx==-1)
        {
            Console.WriteLine("Invalid Book Number");
            return;
        } 

        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Title : {books[bookIdx,0]}");
        Console.WriteLine($"Auther Name : {books[bookIdx,1]}");
        Console.WriteLine($"Status : {books[bookIdx,2]}");
        Console.WriteLine("--------------------------------------------");
    }

    private void UpdateBookStatus()
    {
        int bookIdx = SearchBook();
        if(bookIdx==-1) return;

        bool flag = true;
        while(flag){

            Console.WriteLine("enter new status : [1:checked out , 2:available]");
            int newStatus = Convert.ToInt32(Console.ReadLine());
            int statusIdx = books.GetLength(1)-1;   //2
            switch (newStatus)
            {
                case 1 : {
                    books[bookIdx,statusIdx] = "checked out";
                    flag = false;
                }
                    break;

                case 2 : {
                    books[bookIdx,statusIdx] = "available" ;
                    flag = false;
                }
                    break;

                default : Console.WriteLine("----Wrong Input----");
                break;
            }
        }
        DisplayBook(bookIdx);
    }


}


class Program
{
    static void Main()
    {
        LibraryManagementSystem lms = new LibraryManagementSystem();
        lms.BookMenu();
    }
}