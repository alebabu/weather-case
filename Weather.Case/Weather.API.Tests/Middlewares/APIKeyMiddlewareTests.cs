using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moq;
using Weather.API.Middlewares;

namespace Weather.API.Tests.Middlewares
{
    public class APIKeyMiddlewareTests
    {
        private readonly HttpContext context;
        private readonly RequestDelegate requestDelegate;
        private readonly APIKeyMiddleware middleware;

        private bool requestWasCalled;

        public APIKeyMiddlewareTests()
        {
            // Set up HttpContext
            context = new DefaultHttpContext();

            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    { "X-API-KEY", "valid-key" }
                })
                .Build();

            var spMock = new Mock<IServiceProvider>();
            
            spMock
                .Setup(p => p.GetService(typeof(IConfiguration)))
                .Returns(configuration);

            context.RequestServices = spMock.Object;

            // Set up request delegate
            requestDelegate = _ =>
            {
                requestWasCalled = true;
                return Task.CompletedTask;
            };

            // Initialize middleware
            middleware = new APIKeyMiddleware(requestDelegate);
        }

        [Fact]
        public async Task NoKey_Returns401()
        {
            await middleware.InvokeAsync(context);

            Assert.True(requestWasCalled);
            Assert.Equal(401, context.Response.StatusCode);
        }

        [Fact]
        public async Task InvalidKey_Returns401()
        {
            context.Request.Headers["X-API-Key"] = "invalid-key";

            await middleware.InvokeAsync(context);

            Assert.True(requestWasCalled);
            Assert.Equal(401, context.Response.StatusCode);
        }

        [Fact]
        public async Task ValidKey_Returns200()
        {
            context.Request.Headers["X-API-Key"] = "valid-key";

            await middleware.InvokeAsync(context);

            Assert.True(requestWasCalled);
            Assert.Equal(200, context.Response.StatusCode);
        }
    }
}
