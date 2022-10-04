namespace NLayerCore.Modelss
{
    public class Order:BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal OrderNumber { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }

    }
}