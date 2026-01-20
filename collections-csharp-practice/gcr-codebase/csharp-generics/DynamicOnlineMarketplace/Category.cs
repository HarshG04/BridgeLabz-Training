namespace DynamicOnlineMarketplace
{
    abstract class Category
    {
        public string CategoryName { get; protected set; } = "";
    }

    class BookCategory : Category
    {
        public BookCategory()
        {
            CategoryName = "Books";
        }
    }

    class ClothingCategory : Category
    {
        public ClothingCategory()
        {
            CategoryName = "Clothing";
        }
    }
}
