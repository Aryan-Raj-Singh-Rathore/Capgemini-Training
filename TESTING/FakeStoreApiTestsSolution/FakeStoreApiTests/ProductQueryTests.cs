using System.Collections.Generic;
using System.Net;
using FakeStoreApiTests.Models;
using NUnit.Framework;
using RestSharp;
namespace FakeStoreApiTests
{
    [TestFixture]
    public class ProductQueryTests : BaseApiTests
    {
        [Test]
        public void GetProducts_WithLimitParameter_ReturnsLimitedResults()
        {
            // Arrange
            int limit = 5;
            var request = new RestRequest("products", Method.Get);
            request.AddQueryParameter("limit", limit.ToString());
            // Act
            var response = Client.Execute<List<Product>>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.EqualTo(limit));
        }
        [Test]
        public void
        GetProducts_WithLimitAndSortParameters_ReturnsLimitedSortedResults()
        {
            // Arrange
            int limit = 3;
            string sort = "desc"; // Sort in descending order
            var request = new RestRequest("products", Method.Get);
            request.AddQueryParameter("limit", limit.ToString());
            request.AddQueryParameter("sort", sort);
            // Act
            var response = Client.Execute<List<Product>>(request);
            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data, Is.Not.Null);
            Assert.That(response.Data.Count, Is.EqualTo(limit));
            // Verify products are sorted (assuming sorting by id with desc)
            for (int i = 0; i < response.Data.Count - 1; i++)
            {
                Assert.That(response.Data[i].Id,
                Is.GreaterThanOrEqualTo(response.Data[i + 1].Id));
            }
        }
        [TestCase(0)]
        [TestCase(-1)]
        public void GetProducts_WithInvalidLimit_HandlesInvalidParameter(int invalidLimit)
        {
            // Arrange
            var request = new RestRequest("products", Method.Get);
            request.AddQueryParameter("limit", invalidLimit.ToString());
            // Act
            var response = Client.Execute(request);
            // Assert
            // Note: The FakeStoreAPI may handle invalid parameters differently
            // than a real API. A real API might return 400 Bad Request.
            // Just verifying we get a response
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}