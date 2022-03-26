using ORMFundamentals.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ORMFundamentals.Context
{
    public class MainDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
