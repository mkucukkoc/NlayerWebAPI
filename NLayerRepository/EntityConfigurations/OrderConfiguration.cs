using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.EntityConfigurations
{
    public class OrderConfiguration:IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.OrderNumber).IsRequired().HasColumnType("decimal(18,2)");
             builder.ToTable("Orders");
            builder.HasOne(x=>x.Payment).WithMany(x=>x.Orders).HasForeignKey(x=>x.PaymentId);
            builder.HasOne(x=>x.Shipper).WithMany(x=>x.Orders).HasForeignKey(x=>x.ShipperId);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.Orders).HasForeignKey(x=>x.CustomerId);
        }
    }
}