namespace NLayerCore.Modelss
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ProductFeature ProductFeature { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}