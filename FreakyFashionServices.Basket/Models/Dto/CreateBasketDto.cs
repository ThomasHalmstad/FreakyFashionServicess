using System.Collections.Generic;

namespace FreakyFashionServices.Basket.Models.Dto
{
    public class CreateBasketDto
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}