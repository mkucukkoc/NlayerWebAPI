using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerCore.Servicess;
using NLayerService.Services;

namespace NlayerAPI.Controllers
{
    public class CategoryController : CustomeBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetCategoryByIdWithProducts(categoryId));

        }
    }
}
