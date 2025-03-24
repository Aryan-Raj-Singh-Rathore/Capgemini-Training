using System.Diagnostics;
using NUnit.Framework;
using RestSharp;
namespace FakeStoreApiTests
{
    [TestFixture]
    public class PerformanceTests : BaseApiTests
    {
        [Test]
        public void GetAllProducts_ResponseTimeIsAcceptable()
        {
            // Arrange
            var request = new RestRequest("products", Method.Get);
            var stopwatch = new Stopwatch();
            // Act
            stopwatch.Start();
            var response = Client.Execute(request);
            stopwatch.Stop();
            // Assert
            Assert.That(response.IsSuccessful, Is.True);
            // Assuming an acceptable response time of 1 second
            // Adjust based on API performance expectations
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(1000),
            "API response took longer than 1 second");
        }
        [Test]
        public void MultipleRequests_AverageResponseTimeIsAcceptable()
        {
            // Arrange
            var request = new RestRequest("products", Method.Get);
            var stopwatch = new Stopwatch();
            int requestCount = 5;
            long totalTime = 0;
            // Act
            for (int i = 0; i < requestCount; i++)
            {
                stopwatch.Restart();
                var response = Client.Execute(request);
                stopwatch.Stop();
                Assert.That(response.IsSuccessful, Is.True);
                totalTime += stopwatch.ElapsedMilliseconds;
            }
            long averageTime = totalTime / requestCount;
            // Assert
            // Assuming an acceptable average response time of 500ms
            Assert.That(averageTime, Is.LessThan(500),
            $"Average API response time ({averageTime}ms) exceeded threshold");
        }
    }
}