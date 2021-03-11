using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionService.ProductPrice.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public string ArticleNumber { get; set; }
        public int Price { get; set; }

        public ProductPrice(string articleNumber, int price)
        {
            ArticleNumber = articleNumber;
            Price = price;
        }
    }
}
