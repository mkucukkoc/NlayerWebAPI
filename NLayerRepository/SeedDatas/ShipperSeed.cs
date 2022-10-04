using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas

{
    public class ShipperSeed: IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {   
            builder.HasData(
                new Shipper { Id = 1, CompanyName="Ada",Phone="5444666333" },
                new Shipper { Id = 2, CompanyName="Adalı",Phone="5444445333" },
                new Shipper { Id = 3, CompanyName="Adapazarı",Phone="5224666333" }
            );
        }
    }
}