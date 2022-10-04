using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product { Id = 1, CategoryId = 1,SupplierId=1, Name = "Kalem 1", Price = 100, Stock = 20},
            new Product { Id = 2, CategoryId = 2,SupplierId=1, Name = "Kalem 1", Price = 100, Stock = 20},
            new Product { Id = 3, CategoryId = 2,SupplierId=1, Name = "Kalem 1", Price = 100, Stock = 20}
                      );
        }
    }
}