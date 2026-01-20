namespace SmartWarehouseManagementSystem
{
    class Furniture : WarehouseItem
    {
        public string Material { get; set; }

        public override string GetDetails()
        {
            return $"Furniture Name: {Name}, Material: {Material}, Qty: {Quantity}";
        }
    }
}