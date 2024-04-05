using AllUpMVC.Business.Interfaces;
using AllUpMVC.Data;
using AllUpMVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace AllUpMVC.Business.Implementations
{
    public class SliderService : ISliderService
    {
        private readonly AllUpDbContext _context;

        public SliderService(AllUpDbContext context)
        {
            _context = context;
        }
        public async Task<List<Slider>> GetAllAsync(Expression<Func<Slider, bool>>? expression = null, params string[] includes)
        {
            var query = _context.Sliders.AsQueryable();

            query = _getIncludes(query, includes);

            return expression is not null
                    ? await query.Where(expression).ToListAsync()
                    : await query.ToListAsync();
        }
        private IQueryable<Slider> _getIncludes(IQueryable<Slider> query, params string[] includes)
        {
            if (includes is not null)
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
