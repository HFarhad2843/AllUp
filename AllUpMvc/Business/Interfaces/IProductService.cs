using AllUpMVC.Models;
using System.Linq.Expressions;

namespace AllUpMVC.Business.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetSingleAsync(Expression<Func<Product, bool>>? expression = null, params string[] includes);
        Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>>? expression = null, params string[] includes);
        Task CreateAsync(Product Product);
        Task UpdateAsync(Product Product);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
