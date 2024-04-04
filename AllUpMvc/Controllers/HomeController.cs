using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllUpMVC.Business.Interfaces;
using AllUpMVC.Data;
using AllUpMVC.ViewModels;

namespace AllUpMVC.Controllers;

public class HomeController : Controller
{
    private readonly AllUpDbContext _context;
    private readonly ICategoryService _CategoryService;
    private readonly IProductService _ProductService;

    public HomeController(
            AllUpDbContext context, 
            ICategoryService CategoryService,
            IProductService ProductService)
    {
        _context = context;
        _CategoryService = CategoryService;
        _ProductService = ProductService;
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel homeVM = new HomeViewModel()
        {
       
           Categories = await _CategoryService.GetAllAsync(x=>x.IsDeleted == false),
        
        };
         return View(homeVM);
     
    }
}
