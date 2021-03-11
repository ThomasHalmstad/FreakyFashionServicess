using Microsoft.EntityFrameworkCore;
using System;

namespace FreakyFashionServices.Catalog.Models.Db
{
    public class FreakyFashionContext : DbContext
    {
        public DbSet<Item> Item { get; set; }
        public FreakyFashionContext(DbContextOptions<FreakyFashionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var item = new Item(1, "Black T-Shirt", "Lorem ipsum dolor", 299, 12);
            var itemTwo = new Item(2, "White T-Shirt", "Lorem ipsum dolor", 299, 10);

            builder.Entity<Item>().HasData(item);
            builder.Entity<Item>().HasData(itemTwo);

        }
    }
}
