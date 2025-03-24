using System.Collections.Generic;
using System.Net;
using FakeStoreApiTests.Models;
using NUnit.Framework;
using RestSharp;
namespace FakeStoreApiTests
{
    [TestFixture]
    public class ProductGetTests : BaseApiTests
    {
        [Test]
        public void GetAllProducts_ReturnsSuccessStatusCode()
        {
            // Arrange
            var request = new RestRequest("products", Method.Get);
            // Act
            var response = Client.Execute(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Empty);
        }
        [Test]
        public void GetAllProducts_ReturnsListOfProducts()
        {
            // Arrange
            var request = new RestRequest("products", Method.Get);
            // Act
            var response = Client.Execute<List<Product>>(request);
            // Assert
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
            // Verify the first product has required properties
            var firstProduct = response.Data[0];
            Assert.That(firstProduct.Id, Is.GreaterThan(0));
            Assert.That(firstProduct.Title, Is.Not.Empty);
            Assert.That(firstProduct.Price, Is.GreaterThan(0));
            Assert.That(firstProduct.Category, Is.Not.Empty);
        }
    


        [Test]
        public void GetProductById_WithValidId_ReturnsProduct()
        {
            // Arrange
            int productId = 1;
            var request = new RestRequest($"products/{productId}", Method.Get);
            // Act
            var response = Client.Execute<Product>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Id, Is.EqualTo(productId));
            Assert.That(response.Data.Title, Is.Not.Empty);
            Assert.That(response.Data.Description, Is.Not.Empty);
            Assert.That(response.Data.Price, Is.GreaterThan(0));
        }
        [Test]
        public void GetProductById_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            int invalidProductId = 999999; // Assuming this ID doesn't exist
            var request = new RestRequest($"products/{invalidProductId}", Method.Get);
            // Act
            var response = Client.Execute(request);
            // Assert
            // Note: FakeStoreAPI returns empty string with 200 OK for non-existent items,
            // but in a real API you might expect 404 Not Found
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.EqualTo(""));
        }
        [Test]
        public void GetProductCategories_ReturnsAllCategories()
        {
            // Arrange
            var request = new RestRequest("products/categories", Method.Get);
            // Act
            var response = Client.Execute<List<string>>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
        }
        [Test]
        public void GetProductsByCategory_ReturnsProductsInCategory()
        {
            // Arrange
            string category = "electronics"; // Known category in FakeStoreAPI
            var request = new RestRequest($"products/category/{category}", Method.Get);
            // Act
            var response = Client.Execute<List<Product>>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.GreaterThan(0));
            // Verify all returned products are in the requested category
            foreach (var product in response.Data)
            {
                Assert.That(product.Category, Is.EqualTo(category));
            }
        }
    }
}