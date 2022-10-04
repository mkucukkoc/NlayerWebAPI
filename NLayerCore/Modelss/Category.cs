namespace NLayerCore.Modelss
{
    public class Category:BaseEntity
    {
        //ICollection, öğeler üzerinde numaralandırmayı, öğeleri filtrelemeyi, yeni öğeler eklemeyi, mevcut öğeleri silmeyi, 
        //mevcut öğeleri güncellemeyi ve listedeki kullanılabilir öğelerin sayısını almayı destekler.
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}