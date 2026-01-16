namespace BookShelf
{
    interface IBook
    {
        void AddNewBook(string genre);
        void BorrowBook();
        void ReturnBook();
        // void DeleteBook();
    }
}