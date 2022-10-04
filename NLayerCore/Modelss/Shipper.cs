namespace NLayerCore.Modelss
{
    public class Shipper
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}