using Microsoft.EntityFrameworkCore;
using NLayerCore.Modelss;
using NLayerCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerRepository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithProducts(int categoryıd)
        {
            return await _context.Categories.Include(x => x.Products).Where(x => x.Id == categoryıd).SingleOrDefaultAsync();
        }
    }
}
