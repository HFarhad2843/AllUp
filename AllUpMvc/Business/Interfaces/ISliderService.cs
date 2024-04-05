using AllUpMVC.Models;
using System.Linq.Expressions;

namespace AllUpMVC.Business.Interfaces
{
    public interface ISliderService
    {
        Task<List<Slider>> GetAllAsync(Expression<Func<Slider,bool>>? expression = null, params string[] includes); 
    }
}
