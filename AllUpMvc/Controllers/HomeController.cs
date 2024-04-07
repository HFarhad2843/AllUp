using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllUpMVC.Business.Interfaces;
using AllUpMVC.Data;
using AllUpMVC.ViewModels;
using AllUpMVC.Models;

namespace AllUpMVC.Controllers;

public class HomeController : Controller
{
    private readonly AllUpDbContext _context;
    private readonly ICategoryService _CategoryService;
    private readonly IProductService _ProductService;
    private readonly ISliderService _SliderService;

    public HomeController(
            AllUpDbContext context, 
            ICategoryService CategoryService,
            IProductService ProductService,ISliderService SliderService)
    {
        _context = context;
        _CategoryService = CategoryService;
        _ProductService = ProductService;
        _SliderService= SliderService;  
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel homeVM = new HomeViewModel()
        {
            Categories = await _CategoryService.GetAllAsync(x => x.IsDeleted == false),
            Sliders = await _SliderService.GetAllAsync(x => x.IsDeleted == false),
            BestSellerProducts = await _ProductService.GetAllAsync(x => x.IsDeleted == false && x.IsBestProduct==true, "ProductImages"),
            FeaturedProducts = await _ProductService.GetAllAsync(x => x.IsDeleted == false && x.IsFeatured==true, "ProductImages"),
            NewProducts =await _ProductService.GetAllAsync(x=>x.IsDeleted == false && x.IsNew==true, "ProductImages"),
         };
         return View(homeVM);
     
    }
}
