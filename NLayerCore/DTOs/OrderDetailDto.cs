using NLayerCore.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.DTOs
{
    public class OrderDetailDto
    {
        public decimal OrderNumber { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
