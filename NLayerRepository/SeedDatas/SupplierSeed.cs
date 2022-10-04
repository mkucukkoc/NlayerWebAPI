using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas
{
    public class SupplierSeed: IEntityTypeConfiguration<Supplier>
    {

        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(
                new Supplier { Id = 1, CompanyName = "Ada", Address = "Karatay", City = "Konya", Country = "Turkey", Email = "1234MKK@GMAİL.COM" },
                new Supplier { Id = 2, CompanyName = "Adabalı", Address = "Meram", City = "Konya", Country = "Turkey", Email = "adanalsal@gmail.COM" },
                new Supplier { Id = 3, CompanyName = "Adayalazar", Address = "Çeşme", City = "Izmır", Country = "Turkey", Email = "KK@GMAİL.COM" }
            );
        }
    }
}