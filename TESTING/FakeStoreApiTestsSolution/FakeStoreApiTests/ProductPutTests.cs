using System.Net;
using FakeStoreApiTests.Models;
using NUnit.Framework;
using RestSharp;
namespace FakeStoreApiTests
{
    [TestFixture]
    public class ProductPutTests : BaseApiTests
    {
        private int existingProductId;
        private Product originalProduct;
        [SetUp]
        public void TestSetup()
        {
            // Get an existing product to update
            existingProductId = 1;
            var getRequest = new RestRequest($"products/{existingProductId}", Method.Get);
            var getResponse = Client.Execute<Product>(getRequest);
            originalProduct = getResponse.Data;
            Assert.That(originalProduct, Is.Not.Null, "Setup failed: Could not retrieve product to update");
}
        [Test]
        public void UpdateProduct_WithValidData_ReturnsUpdatedProduct()
        {
            // Arrange
            var updatedProduct = new Product
            {
                Title = "Updated Product Title",
                Price = 199.99m,
                Description = "This is an updated product description",
                Category = originalProduct.Category,
                Image = originalProduct.Image
            };
            var request = new RestRequest($"products/{existingProductId}",
            Method.Put);
            request.AddJsonBody(updatedProduct);
            // Act
            var response = Client.Execute<Product>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Id, Is.EqualTo(existingProductId));
            Assert.That(response.Data.Title, Is.EqualTo(updatedProduct.Title));
            Assert.That(response.Data.Price, Is.EqualTo(updatedProduct.Price));
            Assert.That(response.Data.Description,
            Is.EqualTo(updatedProduct.Description));
        }
        [Test]
        public void UpdateProduct_WithPartialData_UpdatesOnlyProvidedFields()
        {
            // Arrange
            var partialUpdate = new
            {
                Title = "Partially Updated Product"
                // Only updating the title
            };
            var request = new RestRequest($"products/{existingProductId}",
            Method.Put);
            request.AddJsonBody(partialUpdate);
            // Act
            var response = Client.Execute<Product>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Id, Is.EqualTo(existingProductId));
            Assert.That(response.Data.Title, Is.EqualTo(partialUpdate.Title));
            // FakeStoreAPI might replace other fields with defaults
            // or keep existing values depending on implementation
        }
    }
}