using FreakyFashionService.ProductPrice.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace FreakyFashionService.ProductPrice
{
    public class ProductPriceContext : DbContext
    {
        public DbSet<Models.ProductPrice> Product { get; set; }
        public ProductPriceContext(DbContextOptions<ProductPriceContext> options) : base(options)
        {

        }

    }
}
