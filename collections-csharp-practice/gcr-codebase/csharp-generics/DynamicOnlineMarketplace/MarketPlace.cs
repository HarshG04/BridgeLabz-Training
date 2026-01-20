namespace DynamicOnlineMarketplace
{
    abstract class BaseProduct
    {
        public string Name { get; set; } = "";
        public double Price { get; set; }
        public Category Category { get; set; } = null!;

        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category.CategoryName}, Price: {Price}";
        }
    }
    class Product<T> : BaseProduct where T : Category
    {
        public new T Category
        {
            get => (T)base.Category;
            set => base.Category = value;
        }
    }
}
