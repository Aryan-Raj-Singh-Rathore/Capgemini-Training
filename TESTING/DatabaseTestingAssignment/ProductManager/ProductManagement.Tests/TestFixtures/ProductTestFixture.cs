
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data.Data;
using ProductManagement.Data.Services;
using ProductManagement.Tests;

namespace ProductManagement.Tests.TestFixtures
{
    [TestFixture]
    public class ProductTestFixture : TestBase
    {
        protected ProductContext context;
        protected ProductService service;

        [SetUp]
        public void Setup()
        {
            context = CreateSqlServerContext();
            service = new ProductService(context);
        }

        [TearDown]
        public void Cleanup()
        {
            //context.Database.ExecuteSqlRaw("DELETE FROM Products");
            context.Dispose();
        }
    }
}
