namespace Gofabackend.Data
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
        public string VoucherNumber { get; set; }
        public string ReceivedFrom { get; set; }
        public string Condition { get; set; }
        public int Quantity { get; set; }
        public int NumOfBox { get; set; }
        public string RegisteredBy { get; set; }
        public string ItemType { get; set; }
        public string ShelfName { get; set; }
    }
}