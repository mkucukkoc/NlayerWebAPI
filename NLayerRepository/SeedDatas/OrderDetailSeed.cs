using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.Modelss;
namespace NLayerRepository.SeedDatas
{
    public class OrderDetailSeed : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasData(
                new OrderDetail { Id = 1,OrderId=1,ProductId=2,OrderNumber=1,Price=230,Quantity=10,Total=2300, },
                new OrderDetail { Id = 2,OrderId=2,ProductId=1,OrderNumber=1,Price=221,Quantity=10,Total=2210, },
                new OrderDetail { Id = 3,OrderId=3,ProductId=2,OrderNumber=1,Price=230,Quantity=10,Total=2300, }
                      );
        }
    }
}