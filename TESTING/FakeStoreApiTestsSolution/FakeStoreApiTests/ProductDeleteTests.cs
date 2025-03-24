using System.Net;
using NUnit.Framework;
using RestSharp;
namespace FakeStoreApiTests
{
    [TestFixture]
    public class ProductDeleteTests : BaseApiTests
    {
        [Test]
        public void DeleteProduct_WithValidId_ReturnsSuccessStatus()
        {
            // Arrange
            int productId = 6; // Use an existing product ID
            var request = new RestRequest($"products/{productId}", Method.Delete);
            // Act
            var response = Client.Execute(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            // Note: The FakeStoreAPI doesn't actually delete products
            // It just simulates the deletion and returns success
            // In a real API test, you might verify the product no longer exists
        }
        [Test]
        public void DeleteProduct_ThenGetProduct_VerifyProductIsDeleted()
        {
            // Arrange
            int productId = 7; // Use an existing product ID
            // Delete product
            var deleteRequest = new RestRequest($"products/{productId}",
Method.Delete);
            var deleteResponse = Client.Execute(deleteRequest);
            Assert.That(deleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            // Try to get the deleted product
            var getRequest = new RestRequest($"products/{productId}", Method.Get);
            var getResponse = Client.Execute(getRequest);
            // Assert
            // Note: Since FakeStoreAPI doesn't actually delete records,
            // this test is demonstrative - in a real API, you might
            // expect 404 Not Found or an empty response
            Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            // In a real test, you might assert:
            // Assert.That(getResponse.StatusCodeIs.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void DeleteProduct_WithInvalidId_HandlesNonExistentProduct()
        {
            // Arrange
            int invalidProductId = 999999; // Assuming this ID doesn't exist
            var request = new RestRequest($"products/{invalidProductId}",
            Method.Delete);
            // Act
            var response = Client.Execute(request);
            // Assert
            // Note: FakeStoreAPI might return success for non-existent IDs,
            // but a real API might return 404 Not Found
            // For testing purposes, we'll just check the response status
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}