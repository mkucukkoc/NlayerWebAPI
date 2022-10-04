using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas
{
    public class OrderSeed: IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order { Id = 1,CustomerId=1,PaymentId=1,ShipperId=1,OrderNumber = 1},
                new Order { Id = 2,CustomerId=2,PaymentId=2,ShipperId=2,OrderNumber = 2},
                new Order { Id = 3,CustomerId=1,PaymentId=1,ShipperId=1,OrderNumber = 3}
            );
        }
        
    }
}