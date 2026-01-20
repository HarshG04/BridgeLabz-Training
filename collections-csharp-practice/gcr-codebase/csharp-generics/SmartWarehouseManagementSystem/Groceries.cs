namespace SmartWarehouseManagementSystem
{
    class Groceries : WarehouseItem
    {
        public string ExpiryDate { get; set; }

        public override string GetDetails()
        {
            return $"Groceries Name: {Name}, Expiry: {ExpiryDate}, Qty: {Quantity}";
        }
    }
}