using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AllUpMVC.Models;

namespace AllUpMVC.Data;

public class AllUpDbContext : IdentityDbContext<AppUser>
{
    public AllUpDbContext(DbContextOptions<AllUpDbContext> options) : base(options) {}

    public DbSet<Slider> Sliders { get; set; }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<AppUser> users { get; set; }
    public DbSet<Basketitem> BasketItems { get; set; }



}
