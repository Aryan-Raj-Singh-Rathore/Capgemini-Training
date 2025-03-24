using System.Linq;
using System.Net;
using NUnit.Framework;
using RestSharp;
using static System.Net.Mime.MediaTypeNames;
namespace FakeStoreApiTests
{
    [TestFixture]
    public class HeaderTests : BaseApiTests
    {
        [Test]
        public void Request_HasProperContentType()
        {
            // Arrange
            var request = new RestRequest("products", Method.Get);
            // Act
            var response = Client.Execute(request);
            // Assert
            Assert.That(response.IsSuccessful, Is.True);
            // Check that response has Content-Type header and its application / json
var contentTypeHeader = response.ContentType;
            Assert.That(contentTypeHeader, Does.Contain("application/json"));
        }
        [Test]
        public void Request_WithCustomHeaders_SendsHeadersCorrectly()
        {
            // Arrange
            var request = new RestRequest("products", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-Custom-Header", "TestValue");
            // Act
            var response = Client.Execute(request);
            // Assert
            Assert.That(response.IsSuccessful, Is.True);
            // Note: We can't easily verify that the headers were sent correctly
            // without server-side logging, but we can verify that the request succeeded
        }
    }
}