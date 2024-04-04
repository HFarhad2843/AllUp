using AllUpMVC.Models;
using System.Linq.Expressions;

namespace AllUpMVC.Business.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetByIdAsync(int id);
        Task<Category> GetSingleAsync(Expression<Func<Category, bool>>? expression = null);
        Task<List<Category>> GetAllAsync(Expression<Func<Category,bool>>? expression = null, params string[] includes); 
        Task CreateAsync(Category Category);
        Task UpdateAsync(Category Category);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);   
    }
}
