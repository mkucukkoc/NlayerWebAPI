using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.DTOs
{

    /*
     ProductWithCategoryDto productDto dan miras alıyor yani productdto da yer alan herşeyi api kısmında gösterecek ve
     biz categorydto da bir prop olarak veriyoruz.
     */
    public class ProductWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
