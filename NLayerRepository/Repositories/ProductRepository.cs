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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Product>> GetProductWithCategory()
        
        {
           return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
