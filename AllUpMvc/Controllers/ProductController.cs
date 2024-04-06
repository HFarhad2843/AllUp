using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AllUpMVC.Business.Interfaces;
using AllUpMVC.Data;
using AllUpMVC.ViewModels;
using AllUpMVC.Models;
using AllUpMVC.Helpers;
using AllUpMVC.Business.Implementations;

namespace AllUpMVC.Controllers;

public class ProductController : Controller
{
    private readonly AllUpDbContext _context;
    private readonly ICategoryService _CategoryService;
    private readonly IProductService _ProductService;
    private readonly ISliderService _SliderService;

    public ProductController(
            AllUpDbContext context, 
            ICategoryService CategoryService,
            IProductService ProductService,ISliderService SliderService)
    {
        _context = context;
        _CategoryService = CategoryService;
        _ProductService = ProductService;
        _SliderService= SliderService;  
    }

    public async Task<IActionResult> Index(int page)
    {
        ViewBag.Categorys = await _CategoryService.GetAllAsync(x => x.IsDeleted == false);

        var datas = _context.Products.AsQueryable();
        datas=datas.Include(x=>x.Category).Include(x=>x.ProductImages);
        var paginatedDatas = PaginatedList<Product>.Create(datas,2,page);
         return View(paginatedDatas);
     
    }
}
