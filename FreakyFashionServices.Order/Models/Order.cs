using System;
using FreakyFashionServices.Basket.Models.Dto;
using System.Collections.Generic;
using FreakyFashionServices.Basket.Models;

namespace FreakyFashionServices.Order.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
