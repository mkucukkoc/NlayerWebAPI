using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas
{
    public class ProductFeatureSeed : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(EntityTypeBuilder<ProductFeature> builder)
        {   
            builder.HasData(
                new ProductFeature { Id = 1, Color="Kırmzı",Height=100,Width=202,ProductId=1 },
                new ProductFeature { Id = 2, Color="Mavi",Height=30,Width=122,ProductId=1 },
                new ProductFeature { Id = 3, Color="Yesil",Height=49,Width=129,ProductId=1 }
            );
        }
    }
}