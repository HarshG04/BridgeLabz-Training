namespace BookShelf
{
    class BookUtilityImpl : IBook
    {
        private BookNode HeadBookNode = new BookNode();
        private BookNode LastNode;

        public void AddNewBook(string genre)
        {
            BookNode newBook = new BookNode();

            Console.Write("Enter Book Title: ");
            newBook.Title = Console.ReadLine();
            Console.Write("Enter Auther Name: ");
            newBook.AutherName = Console.ReadLine();
            
            newBook.Genre = genre;

            if(HeadBookNode.Next == null)
            {
                HeadBookNode.Next = newBook;
            }
            else
            {   
                LastNode.Next = newBook;
            }
            LastNode = newBook;

            Console.WriteLine("\n"+LastNode);
            Console.WriteLine("New Book Added Successfully!!");
        }

        public void BorrowBook()
        {
            if (HeadBookNode.Next == null)
            {
                Console.WriteLine("No Books In This Gener Available");
                return;
            }

            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine();

            BookNode temp = HeadBookNode.Next;
            while (temp != null)
            {
                if (temp.Title.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    if (temp.Status.Equals("Available"))
                    {
                        temp.Status = "Borrowed";
                        Console.WriteLine(temp);
                        Console.WriteLine("Book Borrowd Succesfully");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Book is Not Available Right Now");
                        return;
                    }
                }

                temp = temp.Next;
            }

            Console.WriteLine("No Book Title Found");
        }

        public void ReturnBook()
        {
            if (HeadBookNode.Next == null)
            {
                Console.WriteLine("Book Shelf Is Not Available");
                return;
            }

            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine();

            BookNode temp = HeadBookNode.Next;
            while (temp != null)
            {
                if (temp.Title.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    if (temp.Status.Equals("Available"))
                    {
                        Console.WriteLine("Book Is Already Available");
                        return;
                    }
                    else
                    {
                        temp.Status = "Available";
                        Console.WriteLine(temp);
                        Console.WriteLine("Book Returned Succesfully");
                        return;
                    }
                }

                temp = temp.Next;
            }

            Console.WriteLine("No Book Title Found");
        }


    }
}