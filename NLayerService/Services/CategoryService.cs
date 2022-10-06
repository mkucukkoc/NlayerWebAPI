using AutoMapper;
using NLayerCore.DTOs;
using NLayerCore.Modelss;
using NLayerCore.Repositories;
using NLayerCore.Servicess;
using NLayerCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerService.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        public readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<GetCategoryByIdWithProducts>> GetCategoryByIdWithProducts(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdWithProducts(categoryId);
            var categoryDto = _mapper.Map<GetCategoryByIdWithProducts>(category);
            return CustomResponseDto<GetCategoryByIdWithProducts>.Success(200, categoryDto);
        }
    }
}
