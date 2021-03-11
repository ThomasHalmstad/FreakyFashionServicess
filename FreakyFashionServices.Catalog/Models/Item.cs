using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Catalog.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AvailableStock { get; set; }

        public Item(int id, string name, string description, int price, int availableStock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            AvailableStock = availableStock;
        }
    }
}
