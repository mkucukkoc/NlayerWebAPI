using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.EntityConfigurations
{
    public class ProductConfigurations:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x=>x.Stock).IsRequired();
            builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("Products");
            builder.HasOne(x=>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.CategoryId);
            builder.HasOne(x=>x.Supplier).WithMany(x=>x.Products).HasForeignKey(x=>x.SupplierId);
        }
    }
}