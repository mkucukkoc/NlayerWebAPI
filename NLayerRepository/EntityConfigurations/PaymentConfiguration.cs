using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.EntityConfigurations
{
    public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.PaymentType).IsRequired().HasMaxLength(50);
            builder.ToTable("Payments");
        }
    }
}