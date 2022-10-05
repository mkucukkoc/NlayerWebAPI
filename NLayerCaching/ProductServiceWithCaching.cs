using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayerCore.DTOs;
using NLayerCore.Modelss;
using NLayerCore.Repositories;
using NLayerCore.Servicess;
using NLayerRepository.UnitOfWork;
using NLayerService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NLayerCaching
{
    public class ProductServiceWithCaching : IProductService
    {

        private const string cacheProductKey = "productsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _productRepository;
        private readonly UnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IProductRepository productRepository, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            //verileri caching etip etmediğini kontrol ediyoruz ve yoksa cach ediyoruz ve verileri ön bellekte bekliyor.
            if (!_memoryCache.TryGetValue(cacheProductKey, out _))
            {
                _memoryCache.Set(cacheProductKey, _productRepository.GetProductWithCategory().Result);
            }
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _productRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _productRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _memoryCache.Get<IEnumerable<Product>>(cacheProductKey);
            return Task.FromResult(products);
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<Product>>(cacheProductKey).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException($"{typeof(Product).Name}({id}) not found");
            }

            return Task.FromResult(product);
        }

        public Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Product entity)
        {
            _productRepository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRange(IEnumerable<Product> entities)
        {
            _productRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task Update(Product entity)
        {
            _productRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(cacheProductKey).Where(expression.Compile()).AsQueryable();
        }
        //Aşagıdaki metot bize verileri her seferinde cache alıp ,getirmemizi sağlıyor.
        public async Task CacheAllProductsAsync()
        {
            _memoryCache.Set(cacheProductKey, await _productRepository.GetAll().ToListAsync());

        }
    }
}
