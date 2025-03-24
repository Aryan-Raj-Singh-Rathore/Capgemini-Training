using ProductManagement.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Tests
{
    public abstract class TestBase
    {
        protected ProductContext CreateInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ProductContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        protected ProductContext CreateSqlServerContext()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseSqlServer("Server=SINGHAL-PC\\SQLEXPRESS;Database=ProductManagement_Tests;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;
            var context = new ProductContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }
    }
}