using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AllUpMVC.Business.Interfaces;
using AllUpMVC.Data;
using AllUpMVC.Models;
using AllUpMVC.ViewModels;

namespace AllUpMVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _ProductService;
        private readonly AllUpDbContext _context;

        public ShopController(
                IProductService ProductService,
                AllUpDbContext context)
        {
            _ProductService = ProductService;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detail(int id) 
        {
            var Product = await _ProductService.GetSingleAsync(x=>x.Id == id,"ProductImages","Category","Author");
            return View(Product);
        }
        public async Task<IActionResult> AddToBasket(int ProductId)
        {
           

            return Ok(); 
        }

        public IActionResult GetBasketItems()
        {
          
               return Ok();

        }



    }
}
