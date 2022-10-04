using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas
{
    public class CustomerSeed: IEntityTypeConfiguration<Customer>
    {
    public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = 1, FirstName = "Mustafa",LastName="Kucukkoc",Class="A",Address="Konya/Turkey", City="Konya",Phone="5454323323",Email="1234567mustafa.mkm@gmail.xom" },
                new Customer { Id = 2, FirstName = "Ali",LastName="Kucukkoc",Class="B",Address="Istanbul/Turkey", City="Istanbul",Phone="5324353453",Email="ali.mkm@gmail.xom" },
                new Customer { Id = 3, FirstName = "Muhammed",LastName="Kucukkoc",Class="C",Address="Adana/Turkey", City="Adana",Phone="5356653453",Email="maho.mkm@gmail.xom" }            );
        }
        
    }
}