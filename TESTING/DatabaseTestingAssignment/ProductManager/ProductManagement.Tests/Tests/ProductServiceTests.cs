using ProductManagement.Data.Data;
using ProductManagement.Data.Services;
using ProductManagement.Data.Models;
using ProductManagement.Tests.TestFixtures;
using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Tests.Tests
{
    [TestFixture]
    public class ProductServiceTests : ProductTestFixture
    {
        [Test]
        public void CreateProduct_ShouldAddProductToDatabase()
        {
            var product = new Product
            {
                //Id = 1,
                Name = "Television",
                Description = "QLED hai, Pleasee lelo Guyss",
                Price = 50000,
                StockQuantity = 200,

            };
            var result = service.CreateProduct(product);
            Assert.That(result.Id, Is.Not.EqualTo(0));
            Assert.That(result.CreatedDate.Date, Is.EqualTo(DateTime.Now.Date));
        }

        [Test]
        public void GetProductById_ShouldReturnCorrectProduct()
        {
            var product = new Product
            {
                //Id = 2,
                Name = "Laptop",
                Description = "Intel i7 hai, PLease Leloo",
                Price = 60000,
                StockQuantity = 100,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            context.Products.Add(product);
            context.SaveChanges();
            
            var result = service.GetProductById(product.Id);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(product.Id));
            Assert.That(result.Name, Is.EqualTo("Laptop"));
        }

        [Test]
        public void UpdateProduct_ShouldModifyExistingProduct()
        {
            var product = new Product
            {
                //Id = 3,
                Name = "Mobile",
                Description = "Iphone hai guyss, With 256Gb storage ke sath leloo ",
                Price = 70000,
                StockQuantity = 1000,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            context.Products.Add(product);
            context.SaveChanges();
            product.Name = "Iphone 16 pro";
            product.Description = "Split Screen Abhi bhi nahi aayega";
            product.StockQuantity = 950;
          
            var result = service.UpdateProduct(product);
            var updatedCustomer = service.GetProductById(product.Id);
          
            Assert.That(result, Is.True);
            Assert.That(updatedCustomer.Name, Is.EqualTo("Iphone 16 pro"));
            Assert.That(updatedCustomer.Description, Is.EqualTo("Split Screen Abhi bhi nahi aayega"));
            Assert.That(updatedCustomer.StockQuantity, Is.EqualTo(950));
        }

        [Test]
        public void DeleteProduct_ShouldRemoveProductFromDatabase()
        {
            var product = new Product
            {
                //Id = 4,
                Name = "Tablet",
                Description = "13 inch ka screen hai, Dekha hai kabhi, Jaldi lelee",
                Price = 30000,
                StockQuantity = 1500,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            context.Products.Add(product);
            context.SaveChanges();
            var result = service.DeleteProduct(product);
            var deletedProduct = context.Products.Find(product.Id);
            Assert.That(deletedProduct, Is.Null);
        }

        [Test]
        public void CreateProduct_ShouldRejectDuplicateProductName()
        {
            var product1 = new Product
            {
                Name = "Unique Product",
                Description = "Mein  hu pehla",
                Price = 10000,
                StockQuantity = 1000,
                IsActive = true,
                CreatedDate = DateTime.Now
            };

            var product2 = new Product
            {
                Name = "Unique Product",  
                Description = "Mein hu doosra",
                Price = 12000,
                StockQuantity = 500,
                IsActive = true,
                CreatedDate = DateTime.Now
            };
            var result = service.CreateProduct(product1);


            Assert.Throws<DbUpdateException>(() => service.CreateProduct(product2));

        }

        [Test]
        public void BulkCreateProduct_ShouldAddProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "HeadPhone",
                    Description = "Zero Latency hai, lele",
                    Price = 10000,
                    StockQuantity = 150,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Name = "Tablet",
                    Description = "13 inch ka screen hai, Dekha hai kabhi, Jaldi lelee",
                    Price = 30000,
                    StockQuantity = 1500,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Name = "Charger",
                    Description = "110W ka charger dekha hai kabhi",
                    Price = 3000,
                    StockQuantity = 1500,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
            };
            var result = service.BulkCreateProducts(products);

            Assert.That(result, Is.True);
            Assert.AreEqual(3, products.Count);

        }

        [Test]
        public void CreateProduct_ShouldRejectNegativePrice()
        {
            var product = new Product
            {
                Name = "Freedom 251",
                Description = "Mein hu nakli phone",
                Price = -500,  
                StockQuantity = 10000,
            };
            var result = service.CreateProduct(product);


            Assert.IsNull(result); 
        }



    }
}