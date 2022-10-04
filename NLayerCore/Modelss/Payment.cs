namespace NLayerCore.Modelss
{
    public class Payment:BaseEntity
    {
        public string PaymentType { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}