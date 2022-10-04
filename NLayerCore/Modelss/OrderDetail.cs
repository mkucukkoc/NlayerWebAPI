namespace NLayerCore.Modelss
{
    public class OrderDetail:BaseEntity
    {
        public decimal OrderNumber { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}