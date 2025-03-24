using NUnit.Framework;
using RestSharp;
namespace FakeStoreApiTests
{
    public class BaseApiTests
    {
        protected RestClient Client;
        protected const string BaseUrl = "https://fakestoreapi.com";
        [SetUp]
        public void Setup()
        {
            Client = new RestClient(BaseUrl);
        }
        [TearDown]
        public void Cleanup()
        {
            Client.Dispose();
        }
    }
}