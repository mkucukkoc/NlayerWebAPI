using NLayerCore.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.DTOs
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public decimal OrderNumber { get; set; }
        public int PaymentId { get; set; }
        public int ShipperId { get; set; }
    }
}
