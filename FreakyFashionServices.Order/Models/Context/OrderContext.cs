﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreakyFashionServices.Order.Models.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }
    }
}
