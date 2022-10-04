using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.EntityConfigurations
{
    public class ProductFeatuereConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Color).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Height).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Width).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("ProductFeatures");
            builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.ProductId);

        }
    }
}