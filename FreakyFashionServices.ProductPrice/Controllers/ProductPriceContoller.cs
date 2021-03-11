using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FreakyFashionService.ProductPrice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductPriceController : ControllerBase
    {
        private readonly ProductPriceContext _context;
        public ProductPriceController(ProductPriceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            string url = Request.QueryString.ToString();

            string[] products = url.Split(',','=');

            products = products.Skip(1).ToArray();

            foreach (var item in products)
            {
                Random random = new Random();
                int price = random.Next(500);
                
                if (item.Length == 6)
                {
                    Models.ProductPrice product = new Models.ProductPrice(item, price);

                    _context.Product.Add(product);
                    _context.SaveChanges();
                }
            }

            return Ok(products);
        }
    }
}
