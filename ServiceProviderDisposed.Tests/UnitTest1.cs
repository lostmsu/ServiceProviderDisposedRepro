using Microsoft.AspNetCore.Mvc.Testing;
using System.Reflection;
using Xunit.Sdk;
using System.Linq;

namespace ServiceProviderDisposed.Tests
{
    public class Tests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public Tests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]

        public async Task Test()
        {
            var client = _factory.CreateClient();

            var response = await client.GetStringAsync("/hello");
            Assert.Equal("Hello", response);
        }
    }
}