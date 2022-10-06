using NLayerCore.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.DTOs
{
    public  class GetCategoryByIdWithProducts:CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
