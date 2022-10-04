using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas
{
    public class PaymentSeed : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData(
                new Payment { Id = 1, PaymentType = "Cash"},
                new Payment { Id = 2, PaymentType = "Card"},
                new Payment { Id = 3, PaymentType = "Cash"}
                      );
        }


    }
}