using System.Net;
using FakeStoreApiTests.Models;
using NUnit.Framework;
using RestSharp;
namespace FakeStoreApiTests
{
    [TestFixture]
    public class ProductPostTests : BaseApiTests
    {
        [Test]
        public void CreateProduct_WithValidData_ReturnsCreatedProduct()
        {
            // Arrange
            var newProduct = new Product
            {
                Title = "Test Product",
                Price = 99.99m,
                Description = "This is a test product created by API test",
                Category = "electronics",
                Image = "https://fakestoreapi.com/img/81QpkIctqPL._AC_SX679_.jpg",
                Rating = new Rating { Rate = 4.5, Count = 10 }
            };
            var request = new RestRequest("products", Method.Post);
            request.AddJsonBody(newProduct);
            // Act
            var response = Client.Execute<Product>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Id, Is.GreaterThan(0)); // FakeStoreAPI assigns an ID
            Assert.That(response.Data.Title, Is.EqualTo(newProduct.Title));
            Assert.That(response.Data.Price, Is.EqualTo(newProduct.Price));
            Assert.That(response.Data.Description,
            Is.EqualTo(newProduct.Description));
            Assert.That(response.Data.Category, Is.EqualTo(newProduct.Category));
        }
        [Test]
        public void CreateProduct_WithMissingRequiredFields_HandlesMissingData()
        {
            // Arrange
            var incompleteProduct = new
            {
                Title = "Incomplete Product"
                // Deliberately missing other fields
            };
            var request = new RestRequest("products", Method.Post);
            request.AddJsonBody(incompleteProduct);
            // Act
            var response = Client.Execute<Product>(request);
            // Assert
            // Note: FakeStoreAPI is lenient with missing fields, but a real might return 400 Bad Request
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Id, Is.GreaterThan(0));
            Assert.That(response.Data.Title, Is.EqualTo(incompleteProduct.Title));
        }
        [Test]
        public void CreateProduct_WithInvalidPrice_HandlesInvalidData()
        {
            // Arrange
            var invalidProduct = new
            {
                Title = "Invalid Product",
                Price = "not-a-number", // Invalid price
                Description = "This product has an invalid price",
                Category = "electronics"
            };
            var request = new RestRequest("products", Method.Post);
            request.AddJsonBody(invalidProduct);
            // Act
            var response = Client.Execute(request);
            // Note: FakeStoreAPI might not validate properly, but we're our approach
            // A real API would likely return 400 Bad Request for invalid data
            // Assert
            // We'll just check the response status rather than making specific assertions
            // about how the API handles invalid data
            Assert.That(response.IsSuccessful, Is.True);
        }
    }
}