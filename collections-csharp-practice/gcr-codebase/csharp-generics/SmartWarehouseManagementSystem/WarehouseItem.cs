namespace SmartWarehouseManagementSystem
{
    abstract class WarehouseItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public abstract string GetDetails();

        public override string ToString()
        {
            return GetDetails();
        }
    }
}