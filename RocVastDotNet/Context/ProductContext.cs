using Microsoft.EntityFrameworkCore;
using RocVastDotNet.Models;
using System.Collections.Generic;

namespace RocVastDotNet.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
