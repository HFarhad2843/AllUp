using Microsoft.EntityFrameworkCore;
using AllUpMVC.Business.Interfaces;
using AllUpMVC.CustomExceptions.Common;
using AllUpMVC.CustomExceptions.CategoryExceptions;
using AllUpMVC.Data;
using AllUpMVC.Models;
using System.Linq.Expressions;

namespace AllUpMVC.Business.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AllUpDbContext _context;

        public CategoryService(AllUpDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category Category)
        {
            if (_context.Categorys.Any(x => x.Name.ToLower() == Category.Name.ToLower()))
                throw new NameAlreadyExistException("Name","Category name is already exist!");

            await _context.Categorys.AddAsync(Category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Categorys.FindAsync(id);
            if (data is null) throw new CategoryNotFoundException("Category not found!");

            _context.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>>? expression = null, params string[] includes) // isdeleted = false
        {
            var query = _context.Categorys.AsQueryable(); // Select * from Categorys

            query = _getIncludes(query, includes);

            return expression is not null 
                    ? await query.Where(expression).ToListAsync()  // Select * From Categorys Where EXPRESSION
                    : await query.ToListAsync(); // SELECT * FROM Categorys
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var data = await _context.Categorys.FindAsync(id);
            if (data is null) throw new CategoryNotFoundException();

            return data;
        }

        public async Task<Category> GetSingleAsync(Expression<Func<Category, bool>>? expression = null)
        {
            var query = _context.Categorys.AsQueryable();

            return expression is not null
                    ? await query.Where(expression).FirstOrDefaultAsync()
                    : await query.FirstOrDefaultAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var data = await _context.Categorys.FindAsync(id);
            if (data is null) throw new CategoryNotFoundException();
            data.IsDeleted = !data.IsDeleted;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category Category)
        {
            var existData = await _context.Categorys.FindAsync(Category.Id);
            if (existData is null) throw new CategoryNotFoundException("Category not found!");
            if (_context.Categorys.Any(x => x.Name.ToLower() == Category.Name.ToLower()) 
                && existData.Name != Category.Name)
                throw new NameAlreadyExistException("Name", "Category name is already exist!");

            existData.Name = Category.Name;
            await _context.SaveChangesAsync();
        }


        private IQueryable<Category> _getIncludes(IQueryable<Category> query, params string[] includes)
        {
            if(includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }


    }
}
