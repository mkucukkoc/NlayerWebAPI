using NLayerCore.DTOs;
using NLayerCore.Modelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCore.Servicess
{
    public interface ICategoryService:IService<Category>
    {
        Task<CustomResponseDto<GetCategoryByIdWithProducts>> GetCategoryByIdWithProducts(int categotyId);   
    }
}
