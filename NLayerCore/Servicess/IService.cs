using System.Linq.Expressions;
namespace NLayerCore.Servicess
{
    public interface IService<T>where T:class
    {
        //iş katamnında kullanılması gereken metotları yazdık.
        //iş katmanında gerekli fluent validation işlemleri yapışlır.
     Task<T> GetByIdAsync(int id);
     Task<IEnumerable<T>> GetAllAsync();
     IQueryable<T> Where (Expression<Func<T,bool>> expression);
     Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
     Task<T> AddAsync(T entity);
     Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
     void Update(T entity);
     void Remove(T entity);
     void RemoveRange(IEnumerable<T>entities); 
    }
}