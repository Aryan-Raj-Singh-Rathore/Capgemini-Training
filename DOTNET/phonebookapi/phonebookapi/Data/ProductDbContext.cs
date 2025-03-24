using phonebookapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace phonebookapi.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) :
       base(options)
        { }
        public DbSet<Product> Products { get; set; }
    }
}
