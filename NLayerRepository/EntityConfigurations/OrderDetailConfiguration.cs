using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.EntityConfigurations
{
    public class OrderDetailConfiguration:IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x=>x.OrderNumber).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x=>x.Quantity).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x=>x.Total).IsRequired().HasColumnType("decimal(18,2)");
            builder.ToTable("OrderDetails");
            //builder.HasOne(x=>x.Order).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.OrderId);
            //builder.HasOne(x=>x.Product).WithMany(x=>x.OrderDetails).HasForeignKey(x=>x.ProductId);
            
        }
    }
}