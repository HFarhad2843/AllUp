using AllUpMVC.Business.Implementations;
using AllUpMVC.Business.Interfaces;

namespace AllUpMVC
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
