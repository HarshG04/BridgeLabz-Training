namespace SmartWarehouseManagementSystem
{
    class Electronics : WarehouseItem
    {
        public string Brand { get; set; }

        public override string GetDetails()
        {
            return $"Electronics Name: {Name}, Brand: {Brand}, Qty: {Quantity}";
        }
    }
}