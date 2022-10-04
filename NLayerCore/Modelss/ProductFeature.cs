namespace NLayerCore.Modelss
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}